﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Job.Init;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using log4net;
using log4net.Config;
using Xin.Repository;
using Microsoft.Extensions.Logging;
using Xin.Entities;

namespace Xin.ExternalService.EC.Job.Init.Tests
{
    [TestClass()]
    public class EcTransitBatchNumberInitTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task JobTestAsync()
        {
            var repository = LogManager.CreateRepository(Common.LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECTransitBatchNumber>)))
                .Returns(new GenericEntityRepository<ECTransitBatchNumber>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);
            EcTransitBatchNumberInit job = new EcTransitBatchNumberInit(provider);
            await job.Job();
        }
    }
}