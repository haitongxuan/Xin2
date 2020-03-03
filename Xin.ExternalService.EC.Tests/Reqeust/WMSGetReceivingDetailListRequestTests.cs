using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSGetReceivingDetailListRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            WMSGetReceivingDetailListReqModel reqModel = new WMSGetReceivingDetailListReqModel();
            reqModel.DateFor = DateTime.Parse("2019-10-01");
            reqModel.DateTo = DateTime.Parse("2020-12-30");
            string[] wharehouseIds = new string[1];
            wharehouseIds[0] = "21";
            reqModel.WarehouseArr = wharehouseIds;
            WMSGetReceivingDetailListRequest req = new WMSGetReceivingDetailListRequest("admin", "eccang123456", reqModel);
            var res = await req.Request();
        }
    }
}