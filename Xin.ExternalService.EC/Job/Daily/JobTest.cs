using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xin.ExternalService.EC.Job.Daily
{
    [DisallowConcurrentExecution]

    public class JobTest : EcBaseJob
    {

        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override Task Job(DateTime? datetime = null)
        {
            System.Diagnostics.Trace.Write("sdsd");

            return Task.Factory.StartNew(() =>
            {
                System.Diagnostics.Trace.Write("sdsd");
            });
        }
    }
}
