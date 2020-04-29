using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.EB;
using Xin.ExternalService.EC.WMS;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xin.ExternalService.EC.Response.Model;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC
{
    /// <summary>
    /// 易仓服务代理类
    /// </summary>
    public class ECService
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ParamsJson { get; set; }
        public string Service { get; set; }
        public string Plateform { get; set; }

        public ECService(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public async Task<ECResponseBody> ResponseServiceAsync()
        {
            ECResponseBody body = new ECResponseBody();
            EB.EcClient ebclient = new EB.EcClient();
            WMS.EcClient wmsclient = new WMS.EcClient();
            string responseJson = "";
            switch (Plateform)
            {
                case "EB":
                    EB.callServiceResponse ebresponse = await ebclient.callServiceAsync(ParamsJson, Username, Password, Service);
                    responseJson = ebresponse.Body.response;
                    break;
                case "WMS":
                    WMS.callServiceResponse wmsresponse = await wmsclient.callServiceAsync(ParamsJson, Username, Password, Service);
                    responseJson = wmsresponse.Body.response;
                    break;
            }

            body = GetECResponse(responseJson);
            if (body.Code != "200" && body.Message != "Success")
            {
                throw new ECExceptoin(body.Service + " error:" + body.Message, body.Error);
            }
            else
            {
                return body;
            }
        }

        /// <summary>
        /// 返回json字符串转对象
        /// </summary>
        /// <param name="responseJson"></param>
        /// <returns></returns>
        public ECResponseBody GetECResponse(string responseJson)
        {
            ECResponseBody data = new ECResponseBody();
            JObject jobject = (JObject)JsonConvert.DeserializeObject(responseJson);
            if (jobject.ContainsKey("code"))
                data.Code = jobject["code"].ToString();
            if (jobject.ContainsKey("message"))
                data.Message = jobject["message"].ToString();
            if (jobject.ContainsKey("page"))
                data.Page = jobject["page"].ToString();
            if (jobject.ContainsKey("pageSize"))
                data.PageSize = jobject["pageSize"].ToString();
            if (jobject.ContainsKey("totalCount"))
            {
                data.TotalCount = jobject["totalCount"].ToString();
            }
            else if (jobject.ContainsKey("count"))
            {
                data.TotalCount = jobject["count"].ToString();
            };
            if (jobject.ContainsKey("service"))
                data.Service = jobject["service"].ToString();
            if (jobject.ContainsKey("responseTime"))
                data.ResponseTime = jobject["responseTime"].ToString();
            if (jobject.ContainsKey("error"))
                data.Error = JsonConvert.DeserializeObject<List<ECError>>(jobject["error"].ToString());
            if (jobject.ContainsKey("data"))
                data.Data = jobject["data"].ToString();
            return data;
        }
    }

}
