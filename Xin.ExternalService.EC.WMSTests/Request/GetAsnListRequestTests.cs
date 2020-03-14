using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.WMS.Request;
using Xin.ExternalService.EC.WMS.Request.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xin.ExternalService.EC.WMS.Request.Tests
{
    [TestClass()]
    public class GetAsnListRequestTests
    {
        [TestMethod()]
        public async Task RequestTest()
        {
            var reqModel = new GetAsnListRequestModel();
            reqModel.page = 1;
            reqModel.pageSize = 100;
            reqModel.receivingCode = "RVA007-200304-0001";

            GetAsnListRequest req = new GetAsnListRequest("7417441d04ea6267a57cbb6cdced5552", "726fb5fbe5b258d33e32aba78df42e83", reqModel);
            var response = await req.Request();
            string s = response.data;
        }
    }
}