﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Xin.ExternalService.EC.Job
{
    public class EcSaleOrderInit : EcBaseJob
    {
        public override async Task Execute(IJobExecutionContext context)
        {
            var reqModel = new Reqeust.Model.EBGetOrderListReqModel();
            var service = new Reqeust.EBGetOrderListRequest(login.Username, login.Password, reqModel);
        }

        public override Task Job()
        {
            throw new NotImplementedException();
        }
    }
}
