using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.Reqeust;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Reqeust.Tests
{
    [TestClass()]
    public class EBGetRmaRefundListRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
            EBGetRmaRefundListReqModel reqModel = new EBGetRmaRefundListReqModel();
            reqModel.Page = 1;
            reqModel.PageSize = 50;
            EBGetRmaRefundListRequest request = new EBGetRmaRefundListRequest("admin", "eccang123456", reqModel);
            var result = await request.Request();
        }
    }
}