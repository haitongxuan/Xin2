using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Response.Model
{
    public class GetAsnListResponseModel
    {
        public string ReceiveCode { get; set; }
        public string ReferenceNo { get; set; }
        public int IncomeType { get; set; }
        public string warehouseCode { get; set; }
        public string TransitWarehouseCode { get; set; }
        public string ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string ReceivingStatus { get; set; }
        public string ReceivingDesc { get; set; }
        public DateTime EtaDate { get; set; }
        public DateTime ReceivingAddTime { get; set; }
        public DateTime ReceivingModifyTime { get; set; }
        public int RegionIdLevel0 { get; set; }
        public int RegionIdLevel1 { get; set; }
        public int RegionIdLevel2 { get; set; }
        public string Street { get; set; }
        public string Contacter { get; set; }
        public string ContactPhone { get; set; }
        public int BoxTotal { get; set; }
        public int SkuTotal { get; set; }
        public int SkuSpecies { get; set; }
    }
}
