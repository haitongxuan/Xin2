using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSGetDeliveryDetailListRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            WMSGetDeliveryDetailListReqModel reqModel = new WMSGetDeliveryDetailListReqModel();
            reqModel.DateFor = DateTime.Parse("2019-10-01");
            reqModel.DateTo = DateTime.Parse("2020-12-30");
            string[] wharehouseIds = new string[1];
            wharehouseIds[0] = "21";
            reqModel.WarehouseArr = wharehouseIds;
            WMSGetDeliveryDetailListRequest req = new WMSGetDeliveryDetailListRequest("admin", "eccang123456", reqModel);
            var response = await req.Request();
        }
    }
}