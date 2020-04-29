using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust
{
   public class WMSInventoryBatchRequest :BaseRequest<WMSInventoryBatchResponse>
    {
        public WMSInventoryBatchRequest(string username, string password, WMSInventoryBatchReqModel reqModel) : base(username, password)
        {
            service.Service = "getInventoryBatch";
            service.Plateform = "WMS";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel);
        }

        public override async Task<WMSInventoryBatchResponse> Request()
        {
            List<EC_InventoryBatch> list = new List<EC_InventoryBatch>();
            try
            {
                var body = await service.ResponseServiceAsync();
                WMSInventoryBatchResponse response = new WMSInventoryBatchResponse(body);
                string data = body.Data;
                //返回字符串中出现时间0000-00-00 00:00:00 导致反序列化异常
                data = data.Replace("0000-00-00 00:00:00", "");
                try
                {
                    list = JsonConvert.DeserializeObject<List<EC_InventoryBatch>>(data);
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
