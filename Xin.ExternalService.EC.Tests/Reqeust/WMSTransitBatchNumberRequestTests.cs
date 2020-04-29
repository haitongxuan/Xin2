using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSTransitBatchNumberRequestTests
    {
        [TestMethod()]
        public void RequestTest()
        {
            WMSGetTransitBatchNumberReqModel reqModel = new WMSGetTransitBatchNumberReqModel();
            WMSTransitBatchNumberRequest req = new WMSTransitBatchNumberRequest("admin", "eccang123456", reqModel);
            var rr = req.Request().Result;
        }
    }
}