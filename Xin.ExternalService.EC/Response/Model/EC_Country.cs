using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
   public class EC_Country
    {
        [JsonProperty(PropertyName = "country_id", NullValueHandling = NullValueHandling.Ignore)]

        public string CountryId { get; set; }
        [JsonProperty(PropertyName = "country_code", NullValueHandling = NullValueHandling.Ignore)]

        public string CountryCode { get; set; }
        [JsonProperty(PropertyName = "country_name", NullValueHandling = NullValueHandling.Ignore)]

        public string CountryName { get; set; }
        [JsonProperty(PropertyName = "country_name_en", NullValueHandling = NullValueHandling.Ignore)]

        public string CountryNameEn { get; set; }
    }
}
