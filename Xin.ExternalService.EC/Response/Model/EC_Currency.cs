using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_Currency
    {
        [JsonProperty(PropertyName = "currency_code", NullValueHandling = NullValueHandling.Ignore)]

        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "currency_name", NullValueHandling = NullValueHandling.Ignore)]

        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "currency_name_en", NullValueHandling = NullValueHandling.Ignore)]

        public string CurrencyNameEn { get; set; }

        [JsonProperty(PropertyName = "currency_rate", NullValueHandling = NullValueHandling.Ignore)]

        public decimal? CurrencyRate { get; set; }

    }
}
