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
            reqModel.createDateFrom = DateTime.Now.AddDays(-10).ToString();
            reqModel.createDateTo = DateTime.Now.ToString();

            GetAsnListRequest req = new GetAsnListRequest("d2684ad701d2111628d418a57ea6d1d0", "b26695abae31081d99eaa8348bcbca42", reqModel);
            var response = await req.Request();
            string s = response.data;
        }
    }
}