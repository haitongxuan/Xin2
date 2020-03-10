using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;
using Newtonsoft.Json;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class EBGetSkuRelationRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {



            EBGetSkuRelationReqModel reqModel = new EBGetSkuRelationReqModel();
            reqModel.Page = 1;
            reqModel.PageSize = 50;
            //var tt = new RequstInfoStruct { paramsJson = JsonConvert.SerializeObject(reqModel), service = "getSkuRelation", userName = "admin", userPass = "eccang123456", url = "http://longqi-eb.eccang.com/default/svc-open/web-service-v2" };
            //string st = GetRequestXML(tt);
            EBGetSkuRelationRequest request = new EBGetSkuRelationRequest("admin", "eccang123456", reqModel);
            var result = await request.Request();
            //int pageNum = (int)Math.Ceiling(int.Parse(result.TotalCount) * 1.0 / 1000);
            //try
            //{
            //    RelationCondition condition = new RelationCondition();
            //    condition.AddTimeStart = "2018-01-01";
            //    condition.AddTimeEnd = DateTime.Now.ToString();
            //    reqModel.Condition = condition;
            //    reqModel.Page = pageNum-1;
            //    reqModel.PageSize = 1000;
            //    request = new EBGetSkuRelationRequest("admin", "eccang123456", reqModel);
            //    result = await request.Request();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        //public static string GetRequestXML(RequstInfoStruct requstInfo)
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
        //    sb.AppendLine("<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"");
        //    sb.AppendLine("\txmlns:ns1=\"http://www.example.org/Ec/\">");
        //    sb.AppendLine("\t<SOAP-ENV:Body>");
        //    sb.AppendLine("\t\t<ns1:callService>");
        //    sb.AppendLine($"\t\t\t<paramsJson>{{{requstInfo.paramsJson}}}</paramsJson>");
        //    sb.AppendLine($"\t\t\t<userName>{requstInfo.userName}</userName>");
        //    sb.AppendLine($"\t\t\t<userPass>{requstInfo.userPass}</userPass>");
        //    sb.AppendLine($"\t\t\t<service>{requstInfo.service}</service>");
        //    sb.AppendLine("\t\t</ns1:callService>");
        //    sb.AppendLine("\t</SOAP-ENV:Body>");
        //    sb.AppendLine("</SOAP-ENV:Envelope>");
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// 公共请求参数
        ///// </summary>
        //public struct RequstInfoStruct
        //{
        //    public object paramsJson;    //请求具体方法所需要的参数
        //    public string userName;    //用户名
        //    public string userPass;    //密码
        //    public string service;    //调用接口名称，比如：syncOrder
        //    public string url;    //用户名
        //}
    }
}