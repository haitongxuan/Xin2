using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
   public class EC_User
    {
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "user_code", NullValueHandling = NullValueHandling.Ignore)]
        public string UserCode { get; set; }
        [JsonProperty(PropertyName = "user_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "user_name_en", NullValueHandling = NullValueHandling.Ignore)]
        public string UserNameEn { get; set; }
    }
}
