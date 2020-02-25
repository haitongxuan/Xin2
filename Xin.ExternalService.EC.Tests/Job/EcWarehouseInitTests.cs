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

namespace Xin.ExternalService.EC.Job.Tests
{
    [TestClass()]
    public class EcWarehouseInitTests
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

            sp.Setup((o) => o.GetService(typeof(IRepository<ECWarehouse>)))
                .Returns(new GenericEntityRepository<ECWarehouse>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);
            try
            {
                EcWarehouseInit job = new EcWarehouseInit(provider);
                await job.Job();
            }
            catch (Exception ex)
            {

            }
        }
        [TestMethod]
        public void GetPerTime()
        {
            var repository = LogManager.CreateRepository(Common.LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECWarehouse>)))
                .Returns(new GenericEntityRepository<ECWarehouse>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);
            EcWarehouseInit ini = new EcWarehouseInit(provider);
            var pretime = ini.GetPreFireDate("0 0 0 */1 * ?");
        }
    }
}