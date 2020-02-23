using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Common;
using Newtonsoft.Json;

namespace Xin.ExternalService.EC.Job
{
    public abstract class EcBaseJob : IJob
    {
        protected readonly EC.LoginModel login;

        public EcBaseJob()
        {
            var config = new AppConfigurationServices().Configuration;
            login = new LoginModel()
            {
                Username = config["ECLogin:Username"],
                Password = config["ECLogin:Password"]
            };
        }

        public abstract Task Execute(IJobExecutionContext context);
        public abstract Task Job();
    }

}
