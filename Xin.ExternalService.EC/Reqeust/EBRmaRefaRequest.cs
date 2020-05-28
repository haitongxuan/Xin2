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
    public class EBRmaRefaRequest : BaseRequest<EBRmaRefaResponse>
    {
        public EBRmaRefaRequest(string username, string password, EBRmaRefaListReqModel reqModel) : base(username, password)
        {
            service.Service = "rmaRefaList";
            service.Plateform = "EB";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel, timeFormat);
        }
        public override async Task<EBRmaRefaResponse> Request()
        {
            List<EC_RmaRefa> list = new List<EC_RmaRefa>();
            try
            {
                var body = await service.ResponseServiceAsync();
                EBRmaRefaResponse response = new EBRmaRefaResponse(body);
                string data = body.Data;
                //返回字符串中出现时间0000-00-00 00:00:00 导致反序列化异常
                //data = data.Replace("0000-00-00 00:00:00", "");
                try
                {
                    list = JsonConvert.DeserializeObject<List<EC_RmaRefa>>(data);
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
