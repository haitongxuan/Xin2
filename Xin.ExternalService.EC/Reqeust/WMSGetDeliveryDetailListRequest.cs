using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
    public class WMSGetDeliveryDetailListRequest:BaseRequest<WMSGetDeliveryDetailListResponse>
    {
        public WMSGetDeliveryDetailListRequest(string username, string password, WMSGetDeliveryDetailListReqModel reqModel) : base(username, password)
        {
            service.Service = "getDeliveryDetailList";
            service.Plateform = "WMS";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel, timeFormat);
        }

        public override async Task<WMSGetDeliveryDetailListResponse> Request()
        {
            
            List<EC_DeliveryDetail> list = new List<EC_DeliveryDetail>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSGetDeliveryDetailListResponse response = new WMSGetDeliveryDetailListResponse(body);
                string data = body.Data;
                list = JsonConvert.DeserializeObject<List<EC_DeliveryDetail>>(data);
                response.Body = list;
                return response;
            }
            catch (ECExceptoin)
            {
                throw;
            }
        }
    }
}
