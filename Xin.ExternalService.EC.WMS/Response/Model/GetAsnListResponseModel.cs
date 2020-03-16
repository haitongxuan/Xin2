using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Xin.ExternalService.EC.WMS.Response.Model
{
    public class GetAsnListResponseModel
    {
        [JsonProperty(PropertyName = "receiving_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiveCode { get; set; }
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        [JsonProperty(PropertyName = "transit_type", NullValueHandling = NullValueHandling.Ignore)]
        public int IncomeType { get; set; }
        [JsonProperty(PropertyName = "warehouse_code", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseCode { get; set; }
        [JsonProperty(PropertyName = "transit_warehouse_code", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitWarehouseCode { get; set; }
        [JsonProperty(PropertyName = "sm_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCode { get; set; }
        [JsonProperty(PropertyName = "shipping_method", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingMethod { get; set; }
        [JsonProperty(PropertyName = "tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingNumber { get; set; }
        [JsonProperty(PropertyName = "receiving_status", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceivingStatus { get; set; }
        [JsonProperty(PropertyName = "receiving_desc", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceivingDesc { get; set; }
        [JsonProperty(PropertyName = "eta_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime EtaDate { get; set; }
        [JsonProperty(PropertyName = "receiving_add_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ReceivingAddTime { get; set; }
        [JsonProperty(PropertyName = "receiving_modify_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ReceivingModifyTime { get; set; }
        [JsonProperty(PropertyName = "region_id_level0", NullValueHandling = NullValueHandling.Ignore)]
        public int RegionIdLevel0 { get; set; }
        [JsonProperty(PropertyName = "region_id_level1", NullValueHandling = NullValueHandling.Ignore)]
        public int RegionIdLevel1 { get; set; }
        [JsonProperty(PropertyName = "region_id_level2", NullValueHandling = NullValueHandling.Ignore)]
        public int RegionIdLevel2 { get; set; }
        [JsonProperty(PropertyName = "street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }
        [JsonProperty(PropertyName = "contacter", NullValueHandling = NullValueHandling.Ignore)]
        public string Contacter { get; set; }
        [JsonProperty(PropertyName = "contact_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactPhone { get; set; }
        [JsonProperty(PropertyName = "box_total", NullValueHandling = NullValueHandling.Ignore)]
        public int BoxTotal { get; set; }
        [JsonProperty(PropertyName = "sku_total", NullValueHandling = NullValueHandling.Ignore)]
        public int SkuTotal { get; set; }
        [JsonProperty(PropertyName = "sku_species", NullValueHandling = NullValueHandling.Ignore)]
        public int SkuSpecies { get; set; }
        [JsonProperty(PropertyName = "calculate_fee_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CalculateFeeTime { get; set; }
        [JsonProperty(PropertyName = "receiving_cost", NullValueHandling = NullValueHandling.Ignore)]
        public List<AsnListCost> ReceivingCost { get; set; }
        [JsonProperty(PropertyName = "items", NullValueHandling = NullValueHandling.Ignore)]
        public List<AsnListItem> Items { get; set; }

    }

    public class AsnListItem
    {
        [JsonProperty(PropertyName = "product_sku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "received_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int ReceivedQuantity { get; set; }
        [JsonProperty(PropertyName = "box_no", NullValueHandling = NullValueHandling.Ignore)]
        public int BoxNo { get; set; }
        [JsonProperty(PropertyName = "loTypeCount", NullValueHandling = NullValueHandling.Ignore)]
        public string[] LoTypeCount { get; set; }
        [JsonProperty(PropertyName = "putaway_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int PutawayQuantity { get; set; }
        [JsonProperty(PropertyName = "product_price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ProductPrice { get; set; }
        [JsonProperty(PropertyName = "warehouse_attr", NullValueHandling = NullValueHandling.Ignore)]
        public WarehouseAtrr WarehouseAtrrs { get; set; }
        [JsonProperty(PropertyName = "product_cost", NullValueHandling = NullValueHandling.Ignore)]
        public List<ProductCost> ProductCosts { get; set; }
    }

    public class AsnListCost
    {
        [JsonProperty(PropertyName = "total_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TotalCost { get; set; }
        [JsonProperty(PropertyName = "shipping_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ShoppingCost { get; set; }
        [JsonProperty(PropertyName = "ccf_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CcfCost { get; set; }
        [JsonProperty(PropertyName = "dt_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal DtCost { get; set; }
        [JsonProperty(PropertyName = "other_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal OtherCost { get; set; }
        [JsonProperty(PropertyName = "customer_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerCurrency { get; set; }
    }

    public class WarehouseAtrr
    {
        [JsonProperty(PropertyName = "product_length", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ProductLength { get; set; }
        [JsonProperty(PropertyName = "product_width", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ProductWidth { get; set; }
        [JsonProperty(PropertyName = "product_height", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ProductHeight { get; set; }
        [JsonProperty(PropertyName = "product_weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ProductWeight { get; set; }
    }

    public class ProductCost : AsnListCost
    {
        [JsonProperty(PropertyName = "head_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal HeadCost { get; set; }
    }
}
