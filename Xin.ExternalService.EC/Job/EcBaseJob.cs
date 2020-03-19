using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Common;
using Newtonsoft.Json;
using Xin.Job;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Logging;
using Xin.Repository;
using Xin.Entities;
using System.IO;

namespace Xin.ExternalService.EC.Job
{
    public abstract class EcBaseJob : BaseJob
    {
        protected readonly EC.LoginModel login;
        protected readonly DateTime now = DateTime.Now;
        public readonly IUowProvider _uowProvider;
        public EcBaseJob()
        {
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECDeliveryDetail>)))
                .Returns(new GenericEntityRepository<ECDeliveryDetail>(logger.Object));

            sp.Setup((o) => o.GetService(typeof(IRepository<ECSalesOrder>)))
                .Returns(new GenericEntityRepository<ECSalesOrder>(logger.Object));

            sp.Setup((o) => o.GetService(typeof(IRepository<ECSalesOrderAddress>)))
                .Returns(new GenericEntityRepository<ECSalesOrderAddress>(logger.Object));

            sp.Setup((o) => o.GetService(typeof(IRepository<ECProduct>)))
                .Returns(new GenericEntityRepository<ECProduct>(logger.Object));

            sp.Setup((o) => o.GetService(typeof(IRepository<ECReceivingDetail>)))
                .Returns(new GenericEntityRepository<ECReceivingDetail>(logger.Object));

            sp.Setup((o) => o.GetService(typeof(IRepository<ECRMARefund>)))
                .Returns(new GenericEntityRepository<ECRMARefund>(logger.Object));

            sp.Setup((o) => o.GetService(typeof(IRepository<ECSkuRelation>)))
                .Returns(new GenericEntityRepository<ECSkuRelation>(logger.Object));
            _uowProvider = new UowProvider(logger.Object, sp.Object);
            var config = new AppConfigurationServices().Configuration;
            login = new LoginModel()
            {
                Username = config["ECLogin:Username"],
                Password = config["ECLogin:Password"]
            };
        }

        public abstract Task Job(DateTime? datetime = null);
    }

}
