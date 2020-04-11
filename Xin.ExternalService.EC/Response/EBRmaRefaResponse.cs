using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
    public class EBRmaRefaResponse : BaseResponse
    {
        public EBRmaRefaResponse(ECResponseBody body) : base(body)
        {
        }
        public List<EC_RmaRefa> Body { get; set; }

    }
}
