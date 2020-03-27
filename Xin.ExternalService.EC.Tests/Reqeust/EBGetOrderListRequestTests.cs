using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class EBGetOrderListRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            EBGetOrderListReqModel reqModel = new EBGetOrderListReqModel();
            reqModel.GetDetail = IsOrNotEnum.Yes;
            reqModel.Page = 1;
            reqModel.PageSize = 1000;
            Conditions c = new Conditions();
            c.Platform = "aliexpress";
            List<string> list = new List<string>();
            list.Add("8011854161306115");
            c.RefNos = list;
            EBGetOrderListRequest req = new EBGetOrderListRequest("admin", "eccang123456", reqModel);
            var rr = await req.Request();
            Assert.Fail();
        }
    }
}