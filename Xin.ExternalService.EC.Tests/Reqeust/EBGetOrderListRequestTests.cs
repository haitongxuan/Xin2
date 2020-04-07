using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;
using log4net;
using log4net.Config;
using System.IO;
using Microsoft.Extensions.Logging;
using Xin.Repository;
using Xin.Entities;
using Xin.Common;
using Xin.ExternalService.EC.Response.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class EBGetOrderListRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            EBGetOrderListReqModel reqModel = new EBGetOrderListReqModel();
            reqModel.GetDetail = IsOrNotEnum.Yes;
            reqModel.Page = 1;
            reqModel.PageSize = 10;
            Conditions c = new Conditions();
            c.Platform = "aliexpress";
            List<string> list = new List<string>();
            list.Add("8011740556136553");
            c.RefNos = list;
            reqModel.Condition = c;
            EBGetOrderListRequest req = new EBGetOrderListRequest("admin", "eccang123456", reqModel);
            var rr = await req.Request();

            var repository = LogManager.CreateRepository(Common.LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECSalesOrder>)))
                .Returns(new GenericEntityRepository<ECSalesOrder>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);

            using (var uow = provider.CreateUnitOfWork())
            {
                var repos = uow.GetRepository<ECSalesOrder>();
                List<ECSalesOrder> insertList = new List<ECSalesOrder>();
                List<ECSalesOrder> updateList = new List<ECSalesOrder>();
                foreach (var item in rr.Body)
                {
                    var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);
                    BnsSendDeliverdToEc temp = new BnsSendDeliverdToEc();
                    temp.ShippingMethodNo = m.ShippingMethodNo;
                    temp.PlatformShipTime = m.PlatformShipTime;
                    m.BnsSendDeliverdToEc_DeliverId = temp;
                    var had = repos.Get(m.OrderId,x=>x.Include(a=>a.BnsSendDeliverdToEc_DeliverId));
                    if (had  != null)
                    {
                        temp.Id = had.BnsSendDeliverdToEc_DeliverId.Id;
                        updateList.Add(m);
                    }
                    else
                    {
                        insertList.Add(m);
                    }
                }
                try
                {
                    insertList = insertList.GroupBy(item => item.OrderId).Select(item => item.First()).ToList();
                    updateList = updateList.GroupBy(item => item.OrderId).Select(item => item.First()).ToList();
                    await repos.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                    await repos.BulkUpdateAsync(updateList, x => x.IncludeGraph = true);
                    uow.BulkSaveChanges();
                    insertList.Clear();
                    updateList.Clear();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            Assert.Fail();
        }
    }
}