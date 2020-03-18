using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Response
{
    public class QueryFbaOrderResponse : BaseResponse<QueryFbaOrderResponse>
    {
        public List<QueryFbaOrderResponse> data { get; set; }
    }
}
