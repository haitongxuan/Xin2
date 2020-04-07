using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
    public class WMSGetUserResponse:BaseResponse
    {
        public WMSGetUserResponse(ECResponseBody body) : base(body)
        {

        }
        public List<EC_User> Body { get; set; }

    }
}
