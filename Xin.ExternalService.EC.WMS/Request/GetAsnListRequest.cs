using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.WMS.Request.Model;
using Xin.ExternalService.EC.WMS.Response;
using Xin.ExternalService.EC.WMS.Response.Model;

namespace Xin.ExternalService.EC.WMS.Request
{
    public class GetAsnListRequest : BaseRequest<GetAsnListResponseModel
        , Model.GetAsnListRequestModel>
    {
        public GetAsnListRequest(string apptoken, string appkey, GetAsnListRequestModel reqModel) : base(apptoken, appkey, reqModel)
        {
            req.service = "getAsnList";
        }

        public override async Task<BaseResponse<GetAsnListResponseModel>> Request()
        {
            var response = new BaseResponse<GetAsnListResponseModel>();
            var rep = await ecClient.callServiceAsync(req.paramsJson, req.appToken, req.appKey, req.service);
            return response;
        }
    }
}
