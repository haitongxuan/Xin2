using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
    public class WMSGetShippingMethodRequest : BaseRequest<WMSGetShippingMethodResponse>
    {
        public WMSGetShippingMethodRequest(string username, string password) : base(username, password)
        {
            service.Service = "getShippingMethod";
            service.Plateform = "WMS";
        }
        public override async Task<WMSGetShippingMethodResponse> Request()
        {
            List<EC_ShippingMethod> list = new List<EC_ShippingMethod>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSGetShippingMethodResponse response = new WMSGetShippingMethodResponse(body);
                string data = body.Data;
                try
                {
                    list = JsonConvert.DeserializeObject<List<EC_ShippingMethod>>(data);
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
