using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSGetShipBatchRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            string order = "test ";
            WMSGetShipBatchRequest req = new WMSGetShipBatchRequest("admin", "eccang123456", order);
            var re = await req.Request();

        }
    }
}