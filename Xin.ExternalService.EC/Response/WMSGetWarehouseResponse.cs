using Xin.ExternalService.EC.Response.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response
{
    public class WMSGetWarehouseResponse : BaseResponse
    {
        public WMSGetWarehouseResponse(ECResponseBody body) : base(body)
        {
        }

        public List<EC_Warehouse> Body { get; set; }
    }
}
