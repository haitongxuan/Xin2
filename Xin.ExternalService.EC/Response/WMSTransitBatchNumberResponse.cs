﻿using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Response
{
   public class WMSTransitBatchNumberResponse : BaseResponse
    {
        public WMSTransitBatchNumberResponse(ECResponseBody body) : base(body)
        {

        }

        public List<EC_TransitBatchNumber> Body { get; set; }

    }
}
