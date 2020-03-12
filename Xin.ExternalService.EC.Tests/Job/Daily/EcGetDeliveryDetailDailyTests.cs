using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Job;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities;
using Xin.Repository;
using Microsoft.Extensions.Logging;
using log4net;
using log4net.Config;
using System.IO;
using System.Threading.Tasks;

namespace Xin.ExternalService.EC.Job.Tests
{
    [TestClass()]
    public class EcGetDeliveryDetailDailyTests
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

            sp.Setup((o) => o.GetService(typeof(IRepository<ECDeliveryDetail>)))
                .Returns(new GenericEntityRepository<ECDeliveryDetail>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);
            try
            {
                EcGetDeliveryDetailDaily job = new EcGetDeliveryDetailDaily(provider);
                await job.Job();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}