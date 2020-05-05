using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.WMS.Response.Model;

namespace Xin.ExternalService.EC.WMS.Response
{
   public class GetOrderListResponse : BaseResponse<GetOrderListResponse>
    {
        public List<GetOrderListResponseModel> data { get; set; }
    }
}
