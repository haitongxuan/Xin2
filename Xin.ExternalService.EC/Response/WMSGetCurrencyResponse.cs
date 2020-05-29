using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
   public class WMSGetCurrencyResponse : BaseResponse
    {
        public WMSGetCurrencyResponse(ECResponseBody body) : base(body)
        {

        }

        public List<EC_Currency> Body { get; set; }
    }
}
