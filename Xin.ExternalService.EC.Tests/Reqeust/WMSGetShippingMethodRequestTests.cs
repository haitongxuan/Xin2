using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Repository;
using Microsoft.Extensions.Logging;
using Xin.Entities;
using Xin.ExternalService.EC.Response.Model;
using Xin.Common;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSGetShippingMethodRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            WMSGetShippingMethodRequest req = new WMSGetShippingMethodRequest("admin", "longqi123456");
            var res = await req.Request();
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECShippingMethod>)))
                .Returns(new GenericEntityRepository<ECShippingMethod>(logger.Object));
            var _uowProvider = new UowProvider(logger.Object, sp.Object);

            List<ECShippingMethod> list = new List<ECShippingMethod>();
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECShippingMethod>();
                foreach (var item in res.Body)
                {
                    var m = Mapper<EC_ShippingMethod, ECShippingMethod>.Map(item);
                    list.Add(m);
                }
                repository.BulkInsert(list, x => x.IncludeGraph = true);
                uow.SaveChanges();

            }
        }
    }
}