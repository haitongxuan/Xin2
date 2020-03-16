using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Response
{
    public class BaseResponse<TEntity>
    {
        public string ask { get; set; }
        public string message { get; set; }
        public Pagination pagenation { get; set; }
        public int count { get; set; }
        public string nextPage { get; set; }
        [JsonProperty(PropertyName = "Error", NullValueHandling = NullValueHandling.Ignore)]
        public Error error { get; set; }
    }
}
