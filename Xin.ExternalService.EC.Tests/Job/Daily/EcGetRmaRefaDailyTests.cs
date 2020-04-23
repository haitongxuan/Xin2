using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Job.Daily;
using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using log4net.Config;
using System.IO;

namespace Xin.ExternalService.EC.Job.Daily.Tests
{
    [TestClass()]
    public class EcGetRmaRefaDailyTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task JobTestAsync()
        {
            var repository = LogManager.CreateRepository(Common.LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            EcGetRmaRefaDaily job = new EcGetRmaRefaDaily();
            await job.Job();
        }
    }
}