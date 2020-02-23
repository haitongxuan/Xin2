using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
    public class WMSGetProductListResponse : BaseResponse
    {
        public WMSGetProductListResponse(ECResponseBody body) : base(body)
        {
        }

        public List<EC_Product> Body { get; set; }
    }
    
}
