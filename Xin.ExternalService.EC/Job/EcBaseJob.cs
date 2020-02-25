using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Common;
using Newtonsoft.Json;
using Xin.Job;

namespace Xin.ExternalService.EC.Job
{
    public abstract class EcBaseJob : BaseJob
    {
        protected readonly EC.LoginModel login;
        protected readonly DateTime now = DateTime.Now;

        public EcBaseJob()
        {
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
