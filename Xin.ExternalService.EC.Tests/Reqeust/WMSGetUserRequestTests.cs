using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Repository;
using Xin.Entities;
using Microsoft.Extensions.Logging;
using Xin.Common;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSGetUserRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task WMSGetUserRequestTestAsync()
        {
            WMSGetUserRequest req = new WMSGetUserRequest("admin", "eccang123456");
            var res = await req.Request();

            //var logger = new Moq.Mock<ILogger<DataAccess>>();
            //var sp = new Moq.Mock<IServiceProvider>();
            //var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            //sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            //sp.Setup((o) => o.GetService(typeof(IRepository<ECUser>)))
            //    .Returns(new GenericEntityRepository<ECUser>(logger.Object));
            //var _uowProvider = new UowProvider(logger.Object, sp.Object);

            //List<ECUser> list = new List<ECUser>();
            //using (var uow = _uowProvider.CreateUnitOfWork())
            //{
            //    var repository = uow.GetRepository<ECUser>();
            //    foreach (var item in res.Body)
            //    {
            //        var m = Mapper<EC_User, ECUser>.Map(item);
            //        list.Add(m);
            //    }
            //    repository.BulkInsert(list, x => x.IncludeGraph = true);
            //    uow.SaveChanges();
            //}
        }
    }
}