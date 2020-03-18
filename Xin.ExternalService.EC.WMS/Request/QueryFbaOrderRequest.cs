using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.WMS.Request.Model;
using Xin.ExternalService.EC.WMS.Response;
using Xin.ExternalService.EC.WMS.Response.Model;

namespace Xin.ExternalService.EC.WMS.Request
{
    public class QueryFbaOrderRequest : BaseRequest<QueryFbaOrderResponse, QueryFbaOrderRequestModel>
    {
        public QueryFbaOrderRequest(string apptoken, string appkey, QueryFbaOrderRequestModel reqModel) : base(apptoken, appkey, reqModel)
        {
            req.service = "queryFbaOrder";
        }

        public override async Task<QueryFbaOrderResponse> Request()
        {
            var rep = await ecClient.callServiceAsync(req.paramsJson, req.appToken, req.appKey, req.service);
            string data = rep.Body.response.Replace("0000-00-00 00:00:00", "");
            data = data.Replace("0000-00-00", "");
            var response = JsonConvert.DeserializeObject<QueryFbaOrderResponse>(data);
            return response;
        }
    }
}
