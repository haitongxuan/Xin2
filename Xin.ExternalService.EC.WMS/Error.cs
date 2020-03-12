using System;

namespace Xin.ExternalService.EC.WMS
{
    public class Error
    {
        public string errMessage { get; set; }
        public string errCode { get; set; }
    }

    public class Pagination
    {
        public string pageSize { get; set; }
        public string page { get; set; }
    }
}
