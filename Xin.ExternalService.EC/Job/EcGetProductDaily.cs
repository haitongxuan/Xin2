using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Entities;
using Xin.Repository;
using Xin.Service;
using Xin.ExternalService.EC.Reqeust;
using Xin.Common;


namespace Xin.ExternalService.EC.Job
{
    public class EcGetProductDaily : EcBaseJob
    {
        public override async Task Execute(IJobExecutionContext context)
        {
            int pageIndex = 0;
            int pageSizd = 50;
        }

        public override Task Job()
        {
            throw new NotImplementedException();
        }
    }
}
