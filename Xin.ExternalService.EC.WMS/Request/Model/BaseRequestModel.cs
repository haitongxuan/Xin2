using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Request.Model
{
    public class BaseRequestModel
    {
        public string appToken { get; set; }
        public string appKey { get; set; }
        public string service { get; set; }
        public string language { get; set; } = "en_US";
        public string paramsJson { get; set; }
    }
}
