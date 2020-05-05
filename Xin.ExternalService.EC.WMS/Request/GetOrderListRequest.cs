using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.WMS.Request.Model;
using Xin.ExternalService.EC.WMS.Response;
using Xin.ExternalService.EC.WMS.Response.Model;

namespace Xin.ExternalService.EC.WMS.Request
{
   public class GetOrderListRequest : BaseRequest<GetOrderListResponse, GetOrderListRequestModel>
    {
        public GetOrderListRequest(string apptoken, string appkey, GetOrderListRequestModel reqModel) : base(apptoken, appkey, reqModel)
        {

            req.service = "getOrderList";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "YYYY-MM-DD HH:II:SS";
            req.paramsJson = JsonConvert.SerializeObject(reqModel);
        }

        public override async Task<GetOrderListResponse> Request()
        {
            var rep = await ecClient.callServiceAsync(req.paramsJson, req.appToken, req.appKey, req.service);
            string data = rep.Body.response.Replace("0000-00-00 00:00:00", "");
            data = data.Replace("0000-00-00", "");
            var response = JsonConvert.DeserializeObject<GetOrderListResponse>(data);
            return response;
        }
    }
}
