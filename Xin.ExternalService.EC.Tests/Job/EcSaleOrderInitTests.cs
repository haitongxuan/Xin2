using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Job;
using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using log4net.Config;
using System.IO;
using Microsoft.Extensions.Logging;
using Xin.Repository;
using Xin.Entities;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Reqeust;

namespace Xin.ExternalService.EC.Job.Tests
{
    [TestClass()]
    public class EcSaleOrderInitTests
    {
        [TestMethod()]
        public async Task JobTest()
        {
            var repository = LogManager.CreateRepository(Common.LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECSalesOrder>)))
                .Returns(new GenericEntityRepository<ECSalesOrder>(logger.Object));
            sp.Setup((o) => o.GetService(typeof(IRepository<ECSalesOrderAddress>)))
                .Returns(new GenericEntityRepository<ECSalesOrderAddress>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);
            try
            {
                EcSaleOrderInit job = new EcSaleOrderInit(provider);
                await job.Job();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public async Task RequestTest()
        {
            var models = new List<ECSalesOrder>();
            var reqModel = new EBGetOrderListReqModel();
            reqModel.PageSize = 50;
            reqModel.GetDetail = IsOrNotEnum.Yes;
            reqModel.GetAddress = IsOrNotEnum.Yes;
            reqModel.Page = 182;
            Reqeust.EBGetOrderListRequest req = new EBGetOrderListRequest("admin", "eccang123456", reqModel);
            Response.EBGetOrderListResponse resp = null;
            resp = await req.Request();
            var data = resp.Body;
        }
    }
}