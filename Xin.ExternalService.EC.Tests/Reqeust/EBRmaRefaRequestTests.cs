using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.Repository;
using Microsoft.Extensions.Logging;
using Xin.Entities;
using Xin.ExternalService.EC.Response.Model;
using Xin.Common;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class EBRmaRefaRequestTests
    {
        [TestMethod()]
        public void RequestTest()
        {
            EBRmaRefaListReqModel reqModel = new EBRmaRefaListReqModel();
            reqModel.Page = 1;
            reqModel.PageSize = 1000;
            EBRmaRefaRequest req = new EBRmaRefaRequest("admin", "eccang123456", reqModel);
            var res = req.Request().Result;
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECRmaRefa>)))
                .Returns(new GenericEntityRepository<ECRmaRefa>(logger.Object));
            var _uowProvider = new UowProvider(logger.Object, sp.Object);

            List<ECRmaRefa> list = new List<ECRmaRefa>();
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECRmaRefa>();
                foreach (var item in res.Body)
                {
                    var m = Mapper<EC_RmaRefa, ECRmaRefa>.Map(item);
                    list.Add(m);
                }
                repository.BulkInsert(list, x => x.IncludeGraph = true);
                uow.SaveChanges();
            }
        }
    }
}