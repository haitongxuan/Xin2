using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
   public class WMSGetCountryRequest : BaseRequest<WMSGetCountryResponse>
    {
        public WMSGetCountryRequest(string username, string password) : base(username, password)
        {
            service.Plateform = "WMS";
            service.Service = "getCountry";
            service.ParamsJson = null;
        }

        public override async Task<WMSGetCountryResponse> Request()
        {
            List<EC_Country> list = new List<EC_Country>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSGetCountryResponse response = new WMSGetCountryResponse(body);

                JObject j = (JObject)JsonConvert.DeserializeObject(body.Data);
                IEnumerable<JProperty> properties = j.Properties();
                foreach (JProperty p in properties)
                {
                    string key = p.Name;
                    EC_Country country = j[key].ToObject<EC_Country>();
                    list.Add(country);
                }
                response.Body = list;
                return response;
            }
            catch (ECExceptoin ex)
            {
                throw;
            }
        }
    }
}
