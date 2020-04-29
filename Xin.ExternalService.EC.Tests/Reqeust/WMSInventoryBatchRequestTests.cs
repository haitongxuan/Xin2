using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;
using log4net;
using log4net.Config;
using System.IO;
using Xin.Repository;
using Microsoft.Extensions.Logging;
using Xin.Entities;
using Xin.Common;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class WMSInventoryBatchRequestTests
    {
        [TestMethod()]
        public void RequestTest()
        {
            WMSInventoryBatchReqModel reqModel = new WMSInventoryBatchReqModel();
            reqModel.Page = 1;
            reqModel.PageSize = 10;
            WMSInventoryBatchRequest req = new WMSInventoryBatchRequest("admin", "eccang123456", reqModel);
            var ee = req.Request().Result;

        }
    }
}