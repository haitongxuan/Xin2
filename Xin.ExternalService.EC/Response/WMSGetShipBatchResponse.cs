using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
   public class WMSGetShipBatchResponse :BaseResponse
    {

        public WMSGetShipBatchResponse(ECResponseBody body) : base(body)
        {

        }

        public List<EC_ShipBatch> Body { get; set; }
    }
}
