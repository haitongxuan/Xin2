using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Common;

namespace Xin.ExternalService.EC.Job.Init
{
    public class EcCurrencyInit : EcBaseJob
    {
        private readonly LogHelper log;
        public EcCurrencyInit()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }
        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override Task Job(DateTime? datetime = null)
        {
            throw new NotImplementedException();
        }
    }
}
