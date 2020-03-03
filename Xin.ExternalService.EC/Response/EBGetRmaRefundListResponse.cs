using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
   public class EBGetRmaRefundListResponse :BaseResponse
    {
        public EBGetRmaRefundListResponse(ECResponseBody body) : base(body)
        {

        }
        public List<EC_RmaRefund> Body { get; set; }

    }
}
