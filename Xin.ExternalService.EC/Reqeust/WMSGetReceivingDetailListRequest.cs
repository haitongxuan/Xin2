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
    public class WMSGetReceivingDetailListRequest : BaseRequest<WMSGetReceivingDetailListResponse>
    {
        public WMSGetReceivingDetailListRequest(string username, string password, WMSGetReceivingDetailListReqModel reqModel) : base(username, password)
        {
            service.Service = "getReceivingDetailList";
            service.Plateform = "WMS";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel, timeFormat);
        }
        public override async Task<WMSGetReceivingDetailListResponse> Request()
        {
            List<EC_ReceivingDetail> list = new List<EC_ReceivingDetail>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSGetReceivingDetailListResponse response = new WMSGetReceivingDetailListResponse(body);
                string data = body.Data;
                list = JsonConvert.DeserializeObject<List<EC_ReceivingDetail>>(data);
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
