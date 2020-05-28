using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
    public class EBGetRmaRefundListRequest :BaseRequest<EBGetRmaRefundListResponse>
    {
        public EBGetRmaRefundListRequest(string username, string password, EBGetRmaRefundListReqModel reqModel) : base(username, password)
        {
            service.Service = "rmaRefundList";
            service.Plateform = "EB";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel, timeFormat);
        }

        public override async Task<EBGetRmaRefundListResponse> Request()
        {
            List<EC_RmaRefund> list = new List<EC_RmaRefund>();
            try
            {
                var body = await service.ResponseServiceAsync();
                EBGetRmaRefundListResponse response = new EBGetRmaRefundListResponse(body);
                string data = body.Data;
                //返回字符串中出现时间0000-00-00 00:00:00 导致反序列化异常
                //data = data.Replace("0000-00-00 00:00:00", "");

                list = JsonConvert.DeserializeObject<List<EC_RmaRefund>>(data);
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
