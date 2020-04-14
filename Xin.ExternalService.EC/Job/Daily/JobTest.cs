using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xin.ExternalService.EC.Job.Daily
{
   public class JobTest : EcBaseJob
    {
        public override async Task Execute(IJobExecutionContext context)
        {

            await Job();
        }

        public override Task Job(DateTime? datetime = null)
        {
            System.Diagnostics.Trace.Write("开始执行");

            return Task.Factory.StartNew(() =>
            {

            });
        }
    }
}
