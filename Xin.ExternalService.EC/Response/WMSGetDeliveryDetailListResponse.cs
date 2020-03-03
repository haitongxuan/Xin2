using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
   public class WMSGetDeliveryDetailListResponse:BaseResponse
    {
        public WMSGetDeliveryDetailListResponse(ECResponseBody body) : base(body)
        {

        }
        public List<EC_DeliveryDetail> Body { get; set; }

    }
}
