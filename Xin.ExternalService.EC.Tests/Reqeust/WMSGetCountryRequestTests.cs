using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Repository;
using log4net;
using log4net.Config;
using System.IO;
using Microsoft.Extensions.Logging;
using Xin.Entities;
using Xin.ExternalService.EC.Response.Model;
using Xin.Common;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSGetCountryRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            WMSGetCountryRequest req = new WMSGetCountryRequest("admin", "eccang123456");
            var ee = await req.Request();

            var repository = LogManager.CreateRepository(Common.LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECCountry>)))
                .Returns(new GenericEntityRepository<ECCountry>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);

            using (var uow = provider.CreateUnitOfWork())
            {
                var repos = uow.GetRepository<ECCountry>();
                List<ECCountry> list = new List<ECCountry>();
                foreach (var item in ee.Body)
                {
                    var m = Mapper<EC_Country, ECCountry>.Map(item);
                    list.Add(m);
                }
                repos.BulkInsert(list, X => X.IncludeGraph = true);
                uow.SaveChanges();

            }

        }
    }
}