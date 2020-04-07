using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
    public class WMSGetShippingMethodResponse : BaseResponse
    {
        public WMSGetShippingMethodResponse(ECResponseBody body) : base(body)
        {
        }

        public List<EC_ShippingMethod> Body { get; set; }

    }
}
