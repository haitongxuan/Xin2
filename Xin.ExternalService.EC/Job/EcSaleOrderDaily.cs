using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Xin.ExternalService.EC.Job
{
    public class EcSaleOrderDaily : EcBaseJob
    {
        public override async Task Execute(IJobExecutionContext context)
        {
            var reqModel = new Reqeust.Model.EBGetOrderListReqModel();
            var service = new Reqeust.EBGetOrderListRequest(login.Username, login.Password, reqModel);
        }

        public override Task Job(DateTime? datetime = null)
        {
            throw new NotImplementedException();
        }
    }
}
