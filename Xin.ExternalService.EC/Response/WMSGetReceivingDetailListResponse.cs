using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
    public class WMSGetReceivingDetailListResponse :BaseResponse
    {
        public WMSGetReceivingDetailListResponse(ECResponseBody body) : base(body)
        {

        }
        public List<EC_ReceivingDetail> Body { get; set; }
    }
}
