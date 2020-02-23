using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xin.ExternalService.EC.Reqeust
{
    public class EBGetOrderListRequest : BaseRequest<EBGetOrderListResponse>
    {
        public EBGetOrderListRequest(string username, string password, EBGetOrderListReqModel reqModel) : base(username, password)
        {
            service.Service = "getOrderList";
            service.Plateform = "EB";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel);
        }
        public override async Task<EBGetOrderListResponse> Request()
        {
            List<EC_SalesOrder> list = new List<EC_SalesOrder>();
            try
            {
                var body = await service.ResponseServiceAsync();
                EBGetOrderListResponse response = new EBGetOrderListResponse(body);
                string data = body.Data;
                //返回字符串中出现时间0000-00-00 00:00:00 导致反序列化异常
                data = data.Replace("0000-00-00 00:00:00", "");

                list = JsonConvert.DeserializeObject<List<EC_SalesOrder>>(data);
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
