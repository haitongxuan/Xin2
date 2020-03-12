using EC.OMS.Service;
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
    public abstract class BaseRequest<TResponse, TReqModel> where TResponse : class
        where TReqModel : class
    {
        protected readonly EcClient ecClient;
        protected BaseRequestModel req;
        public BaseRequest(string apptoken, string appkey, TReqModel reqModel)
        {
            req = new BaseRequestModel();
            ecClient = new EcClient();
            req.appKey = appkey;
            req.appToken = apptoken;
            try
            {
                req.paramsJson = JsonConvert.SerializeObject(reqModel); ;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public abstract Task<BaseResponse<TResponse>> Request();
    }
}
