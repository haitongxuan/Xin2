using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
   public class SaleOrderDetail
    {
        public long RowNumber { get; set; }

        public string SaleOrderCode { get; set; }
        public string Plateform { get; set; }
        public string UserAccount { get; set; }
        public int? ProcessAgain { get; set; }
        public int? PlatformShipStatus { get; set; }
        public int? Status { get; set; }
        public string Sku { get; set; }
        public int Qty { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public string Density { get; set; }
        public string HandArea { get; set; }
        public string ProductCategory { get; set; }
        public string Type { get; set; }
    }
}
