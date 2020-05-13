﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
    public class WMSGetShipBatchRequest : BaseRequest<WMSGetShipBatchResponse>
    {
        public WMSGetShipBatchRequest(string username, string password, WMSShipBatchReqModel orderCode) : base(username, password)
        {
            service.Service = "getShipBatch";
            service.Plateform = "WMS";
            service.ParamsJson = JsonConvert.SerializeObject(orderCode);

        }
        public override async Task<WMSGetShipBatchResponse> Request()
        {
            try
            {
                List<EC_ShipBatch> model = new List<EC_ShipBatch>();
                var body = await service.ResponseServiceAsync();
                WMSGetShipBatchResponse response = new WMSGetShipBatchResponse(body);
                string data = body.Data.Replace("0000-00-00 00:00:00", "");

                if (data != "[]")
                {
                    model = JsonConvert.DeserializeObject<List<EC_ShipBatch>>(data);
                }
                response.Body = model;
                return response;
            }
            catch (ECExceptoin)
            {
                throw;
            }
        }
    }
}
