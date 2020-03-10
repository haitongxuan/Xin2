using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
   public class EBGetSkuRelationResponse :BaseResponse
    {
        public EBGetSkuRelationResponse(ECResponseBody body) : base(body)
        {

        }

        public List<EC_SkuRelation> Body { get; set; }
    }
}
