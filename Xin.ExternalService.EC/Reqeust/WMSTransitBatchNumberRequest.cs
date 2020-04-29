using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
   public class WMSTransitBatchNumberRequest : BaseRequest<WMSTransitBatchNumberResponse>
    {
        public WMSTransitBatchNumberRequest(string username, string password, WMSGetTransitBatchNumberReqModel reqModel) : base(username, password)
        {
            service.Service = "getTransitBatchNumber";
            service.Plateform = "WMS";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel);

        }
        public override async Task<WMSTransitBatchNumberResponse> Request()
        {
            List<EC_TransitBatchNumber> list = new List<EC_TransitBatchNumber>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSTransitBatchNumberResponse response = new WMSTransitBatchNumberResponse(body);
                string data = body.Data;
                try
                {
                    list = JsonConvert.DeserializeObject<List<EC_TransitBatchNumber>>(data);
                    response.Body = list;
                    return response;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (ECExceptoin ex)
            {
                throw ex;
            }
        }
    }
}
