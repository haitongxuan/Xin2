﻿using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
   public class WMSInventoryBatchResponse: BaseResponse
    {
        public WMSInventoryBatchResponse(ECResponseBody body) : base(body)
        {

        }
        public List<EC_InventoryBatch> Body { get; set; }

    }
}
