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
    public class EBGetSkuRelationRequest : BaseRequest<EBGetSkuRelationResponse>
    {
        public EBGetSkuRelationRequest(string username, string password, EBGetSkuRelationReqModel reqModel) : base(username, password)
        {
            service.Service = "getSkuRelation";
            service.Plateform = "EB";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            service.ParamsJson = JsonConvert.SerializeObject(reqModel, timeFormat);
        }
        public override async Task<EBGetSkuRelationResponse> Request()
        {
            List<EC_SkuRelation> list = new List<EC_SkuRelation>();
            try
            {
                var body = await service.ResponseServiceAsync();
                EBGetSkuRelationResponse response = new EBGetSkuRelationResponse(body);
                string data = body.Data;
                //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\LQAPP\XIN\sku.txt", true))
                //{
                //    file.WriteLine(data+"; \n");
                //}
                try
                {
                    list = JsonConvert.DeserializeObject<List<EC_SkuRelation>>(data);
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
