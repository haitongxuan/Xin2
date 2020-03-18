using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Request.Model
{
    public class QueryFbaOrderRequestModel : BaseRequestModel
    {
        [JsonProperty(PropertyName = "fba_code", NullValueHandling = NullValueHandling.Ignore)]
        public string FbaCode { get; set; }
    }
}
