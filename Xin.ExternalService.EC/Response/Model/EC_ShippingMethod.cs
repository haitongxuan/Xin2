using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_ShippingMethod
    {

        [JsonProperty(PropertyName = "sm_id", NullValueHandling = NullValueHandling.Ignore)]
        public int SmId { get; set; }
        [JsonProperty(PropertyName = "sm_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCode { get; set; }
        [JsonProperty(PropertyName = "sm_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SmName { get; set; }
        [JsonProperty(PropertyName = "sm_name_cn", NullValueHandling = NullValueHandling.Ignore)]
        public string SmNameCn { get; set; }
        [JsonProperty(PropertyName = "sm_carrier_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCarrierName { get; set; }
        [JsonProperty(PropertyName = "sm_carrier_name_cn", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCarrierNameCn { get; set; }
    }
}
