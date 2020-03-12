using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Response.Model;
using System.ComponentModel;
using Newtonsoft.Json.Converters;

namespace Xin.ExternalService.EC.Reqeust
{
    public class WMSGetProductListRequest : BaseRequest<WMSGetProductListResponse>
    {
        public WMSGetProductListRequest(string username, string password, WMSGetProductListReqModel reqModel) : base(username, password)
        {
            service.Service = "getProductList";
            service.Plateform = "WMS";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel, timeFormat);
        }
        public override async Task<WMSGetProductListResponse> Request()
        {
            List<EC_Product> list = new List<EC_Product>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSGetProductListResponse response = new WMSGetProductListResponse(body);
                string data = body.Data;
                //返回字符串中出现时间0000-00-00 00:00:00 导致反序列化异常
                data = data.Replace("0000-00-00 00:00:00", "");

                list = JsonConvert.DeserializeObject<List<EC_Product>>(data);
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
