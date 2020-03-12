using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Request.Model
{
    public class GetAsnListRequestModel
    {
        public int pageSize { get; set; }
        public int page { get; set; }
        [JsonProperty(PropertyName = "receiving_code", NullValueHandling = NullValueHandling.Ignore)]
        public string receivingCode { get; set; }
        [JsonProperty(PropertyName = "receiving_code_arr", NullValueHandling = NullValueHandling.Ignore)]
        public string[] receivingCodeArr { get; set; }

        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string referenceNo { get; set; }

        [JsonProperty(PropertyName = "reference_no_arr", NullValueHandling = NullValueHandling.Ignore)]
        public string referenceNoArr { get; set; }

        [JsonProperty(PropertyName = "create_date_from", NullValueHandling = NullValueHandling.Ignore)]
        public string createDateFrom { get; set; }

        [JsonProperty(PropertyName = "create_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public string createDateTo { get; set; }
        [JsonProperty(PropertyName = "modify_date_from", NullValueHandling = NullValueHandling.Ignore)]
        public string modifyDateFrom { get; set; }
        [JsonProperty(PropertyName = "modify_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public string modifyDateTo { get; set; }
        [JsonProperty(PropertyName = "business_type", NullValueHandling = NullValueHandling.Ignore)]
        public string businessType { get; set; }
    }
}
