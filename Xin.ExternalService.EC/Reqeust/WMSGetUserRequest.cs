using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
    public class WMSGetUserRequest : BaseRequest<WMSGetUserResponse>
    {
        public WMSGetUserRequest(string username, string password):base(username, password)
        {
            service.Service = "getUser";
            service.Plateform = "WMS";
        }
        public override async Task<WMSGetUserResponse> Request()
        {
            List<EC_User> list = new List<EC_User>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSGetUserResponse response = new WMSGetUserResponse(body);
                string data = body.Data;
                try
                {
                    list = JsonConvert.DeserializeObject<List<EC_User>>(data);
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
