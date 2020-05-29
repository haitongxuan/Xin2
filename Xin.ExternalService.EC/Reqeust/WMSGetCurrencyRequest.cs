using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
    public class WMSGetCurrencyRequest : BaseRequest<WMSGetCurrencyResponse>
    {
        public WMSGetCurrencyRequest(string username, string password) : base(username, password)
        {
            service.Service = "getCurrency";
            service.Plateform = "WMS";
        }
        public override async Task<WMSGetCurrencyResponse> Request()
        {
            List<EC_Currency> list = new List<EC_Currency>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSGetCurrencyResponse response = new WMSGetCurrencyResponse(body);
                string data = body.Data;
                try
                {
                    list = JsonConvert.DeserializeObject<List<EC_Currency>>(data);
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
