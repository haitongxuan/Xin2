using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.Logging;
using Xin.Repository;
using Xin.Entities;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Job.Tests
{
    [TestClass()]
    public class EcGetProductDailyTests
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

            sp.Setup((o) => o.GetService(typeof(IRepository<ECProduct>)))
                .Returns(new GenericEntityRepository<ECProduct>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);
            try
            {
                EcGetProductDaily job = new EcGetProductDaily();
                await job.Job();
            }
            catch (Exception ex)
            {

            }
        }
    }
}