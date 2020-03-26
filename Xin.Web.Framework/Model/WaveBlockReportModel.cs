using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Web.Framework.Model
{
   public class WaveBlockReportModel
    {
        public string Size { get; set; }
        public int Total { get; set; }
        public int SizeTotal { get; set; }
        public string SizeTotalRatio { get; set; }
        public List<PlatformDetail> Data { get; set; }

    }

    public class PlatformDetail {
        public string Plate { get; set; }
        public int SaleNum { get; set; }
        public string SalesRatio { get; set; }
    }
}
