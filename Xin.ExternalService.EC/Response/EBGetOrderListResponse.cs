using Xin.ExternalService.EC.Response.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response
{
   public class EBGetOrderListResponse : BaseResponse
    {
        public EBGetOrderListResponse(ECResponseBody body) : base(body)
        {
        }

        public List<EC_SalesOrder> Body { get; set; }
    }
}
