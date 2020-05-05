using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.WMS.Request;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.WMS.Request.Model;
using Xin.Repository;
using Microsoft.Extensions.Logging;
using Xin.Entities;
using Xin.Common;
using Xin.ExternalService.EC.WMS.Response.Model;

namespace Xin.ExternalService.EC.WMS.Request.Tests
{
    [TestClass()]
    public class GetOrderListRequestTests
    {
        [TestMethod()]
        public void RequestTest()
        {
            GetOrderListRequestModel reqModel = new GetOrderListRequestModel();
            reqModel.Page = 1;
            reqModel.PageSize = 1000;
           var req  = new  GetOrderListRequest( "7417441d04ea6267a57cbb6cdced5552", "726fb5fbe5b258d33e32aba78df42e83", reqModel);
           var res = req.Request().Result;

            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<OmsOrderList>)))
                .Returns(new GenericEntityRepository<OmsOrderList>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);

            using (var uow = provider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<OmsOrderList>();
                List<OmsOrderList> list = new List<OmsOrderList>();
                foreach (var item in res.data)
                {
                    var tt = Mapper<GetOrderListResponseModel, OmsOrderList>.Map(item);
                    list.Add(tt);

                }
                repository.BulkInsert(list,x=>x.IncludeGraph = true);
                uow.SaveChanges();

            }
        }
    }
}