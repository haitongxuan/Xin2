using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
    public class SingleProductSell
    {
        public string Plateform { get; set; }
        public string UserAccount { get; set; }
        public string SaleOrderCode { get; set; }
        public string ShippingMethodPlatform { get; set; }
        public string ShippingMethod { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseId { get; set; }
        public DateTime? DatePaidPlatform { get; set; }
        public DateTime? PlatformShipTime { get; set; }
        public DateTime? DateLatestShip { get; set; }
        public string Currency { get; set; }
        public string CountryCode { get; set; }
        public int? ProductCount { get; set; }

        public int? Qty { get; set; }
        public string SubProductSku { get; set; }
        public int? SubQty { get; set; }
    }
}
