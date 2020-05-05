using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Response.Model
{
    public class GetOrderListResponseModel
    {
        /// <summary> 
        ///公司代码
        /// <summary> 
        [JsonProperty(PropertyName = "company_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyCode { get; set; }
        /// <summary> 
        ///订单号
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///客户参考号
        /// <summary> 
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///平台
        /// <summary> 
        [JsonProperty(PropertyName = "platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }
        /// <summary> 
        ///订单状态 C:待发货审核 W:待发货 D:已发货 H:暂存 N:异常订单 P:问题件 X:废弃
        /// <summary> 
        [JsonProperty(PropertyName = "order_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderStatus { get; set; }
        /// <summary> 
        ///运输方式
        /// <summary> 
        [JsonProperty(PropertyName = "shipping_method", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingMethod { get; set; }
        /// <summary> 
        ///跟踪号
        /// <summary> 
        [JsonProperty(PropertyName = "tracking_no", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingNo { get; set; }
        /// <summary> 
        ///仓库Id
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseId { get; set; }
        /// <summary> 
        ///仓库代码
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_code", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseCode { get; set; }
        /// <summary> 
        ///订单重量
        /// <summary> 
        [JsonProperty(PropertyName = "order_weight", NullValueHandling = NullValueHandling.Ignore)]
        public float? OrderWeight { get; set; }
        /// <summary> 
        ///订单说明
        /// <summary> 
        [JsonProperty(PropertyName = "order_desc", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderDesc { get; set; }
        /// <summary> 
        ///创建时间
        /// <summary> 
        [JsonProperty(PropertyName = "date_create", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateCreate { get; set; }
        /// <summary> 
        ///审核时间
        /// <summary> 
        [JsonProperty(PropertyName = "date_release", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateRelease { get; set; }
        /// <summary> 
        ///出库时间
        /// <summary> 
        [JsonProperty(PropertyName = "date_shipping", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateShipping { get; set; }
        /// <summary> 
        ///修改时间
        /// <summary> 
        [JsonProperty(PropertyName = "date_modify", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateModify { get; set; }
        /// <summary> 
        ///收件人国家二字码
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeCountryCode { get; set; }
        /// <summary> 
        ///收件人国家
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_country_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeCountryName { get; set; }
        /// <summary> 
        ///省
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_state", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeState { get; set; }
        /// <summary> 
        ///城市
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_city", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeCity { get; set; }
        /// <summary> 
        ///区域
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_district", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeDistrict { get; set; }
        /// <summary> 
        ///地址1
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_street1", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeStreet1 { get; set; }
        /// <summary> 
        ///地址2
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_street2", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeStreet2 { get; set; }
        /// <summary> 
        ///地址3
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_street3", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeStreet3 { get; set; }
        /// <summary> 
        ///邮编
        /// <summary> 
        [JsonProperty(PropertyName = "consigne_zipcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneZipcode { get; set; }
        /// <summary> 
        ///门牌号
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_doorplate", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeDoorplate { get; set; }
        /// <summary> 
        ///公司
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_company", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeCompany { get; set; }
        /// <summary> 
        ///收件人名称
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeName { get; set; }
        /// <summary> 
        ///收件人电话
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneePhone { get; set; }
        /// <summary> 
        ///收件人邮箱
        /// <summary> 
        [JsonProperty(PropertyName = "consignee_email", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsigneeEmail { get; set; }
        /// <summary> 
        ///异常信息
        /// <summary> 
        [JsonProperty(PropertyName = "abnormal_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string AbnormalReason { get; set; }
        /// <summary> 
        ///第三方渠道承运商
        /// <summary> 
        [JsonProperty(PropertyName = "courier_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CourierName { get; set; }
        /// <summary> 
        ///渠道代码
        /// <summary> 
        [JsonProperty(PropertyName = "channel_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelCode { get; set; }
        /// <summary> 
        ///COD订单：0:否 1:是
        /// <summary> 
        [JsonProperty(PropertyName = "is_order_cod", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsOrderCod { get; set; }
        /// <summary> 
        ///COD Value
        /// <summary> 
        [JsonProperty(PropertyName = "order_cod_price", NullValueHandling = NullValueHandling.Ignore)]
        public float? OrderCodPrice { get; set; }
        /// <summary> 
        ///COD币种
        /// <summary> 
        [JsonProperty(PropertyName = "order_cod_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCodCurrency { get; set; }
        /// <summary> 
        ///费用总结
        /// <summary> 
        [JsonProperty(PropertyName = "fee_summery", NullValueHandling = NullValueHandling.Ignore)]
        public FeeSumery FeeSummery { get; set; }
        /// <summary> 
        ///订单明细
        /// <summary> 
        [JsonProperty(PropertyName = "items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Item> Items { get; set; }
        /// <summary> 
        ///订单费用
        /// <summary> 
        [JsonProperty(PropertyName = "order_fee", NullValueHandling = NullValueHandling.Ignore)]
        public List<OrderFee> OrderFee { get; set; }
        /// <summary> 
        ///SKU出库批次
        /// <summary> 
        [JsonProperty(PropertyName = "inventory_batch_out", NullValueHandling = NullValueHandling.Ignore)]
        public List<InventoryBatchOut> InventoryBatchOut { get; set; }

    }
    public class FeeSumery
    {
        /// <summary> 
        ///订单号
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///运输方式
        /// <summary> 
        [JsonProperty(PropertyName = "shipping_method", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingMethod { get; set; }
        /// <summary> 
        ///国家编码
        /// <summary> 
        [JsonProperty(PropertyName = "country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }
        /// <summary> 
        ///订单重量
        /// <summary> 
        [JsonProperty(PropertyName = "order_weight", NullValueHandling = NullValueHandling.Ignore)]
        public float? OrderWeight { get; set; }
        /// <summary> 
        ///费用状态:已核账，未核账
        /// <summary> 
        [JsonProperty(PropertyName = "fee_status", NullValueHandling = NullValueHandling.Ignore)]
        public string FeeStatus { get; set; }
        /// <summary> 
        ///变更为已核账状态的时间，年月日时分秒
        /// <summary> 
        [JsonProperty(PropertyName = "fee_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FeeTime { get; set; }
        /// <summary> 
        ///运费
        /// <summary> 
        [JsonProperty(PropertyName = "ship_cost", NullValueHandling = NullValueHandling.Ignore)]
        public float? ShipCost { get; set; }
        /// <summary> 
        ///操作费
        /// <summary> 
        [JsonProperty(PropertyName = "op_cost", NullValueHandling = NullValueHandling.Ignore)]
        public float? OpCost { get; set; }
        /// <summary> 
        ///燃油附加费
        /// <summary> 
        [JsonProperty(PropertyName = "fuel_cost", NullValueHandling = NullValueHandling.Ignore)]
        public float? FuelCost { get; set; }
        /// <summary> 
        ///挂号费
        /// <summary> 
        [JsonProperty(PropertyName = "register_cost", NullValueHandling = NullValueHandling.Ignore)]
        public float? RegisterCost { get; set; }
        /// <summary> 
        ///仓储费
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_cost", NullValueHandling = NullValueHandling.Ignore)]
        public float? WarehouseCost { get; set; }
        /// <summary> 
        ///关税
        /// <summary> 
        [JsonProperty(PropertyName = "tariff_cost", NullValueHandling = NullValueHandling.Ignore)]
        public float? TariffCost { get; set; }
        /// <summary> 
        ///其他费用
        /// <summary> 
        [JsonProperty(PropertyName = "incidental_cost", NullValueHandling = NullValueHandling.Ignore)]
        public float? IncidentalCost { get; set; }

    }
    public class Item
    {
        /// <summary> 
        ///产品Id
        /// <summary> 
        [JsonProperty(PropertyName = "product_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }
        /// <summary> 
        ///SKU
        /// <summary> 
        [JsonProperty(PropertyName = "product_sku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }
        /// <summary> 
        ///数量
        /// <summary> 
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Quantity { get; set; }

    }
    public class OrderFee
    {
        /// <summary> 
        ///类型
        /// <summary> 
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        /// <summary> 
        ///费用
        /// <summary> 
        [JsonProperty(PropertyName = "amount", NullValueHandling = NullValueHandling.Ignore)]
        public float? Amount { get; set; }
        /// <summary> 
        ///币种
        /// <summary> 
        [JsonProperty(PropertyName = "currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }

    }
    public class InventoryBatchOut
    {
        /// <summary> 
        ///入库单号
        /// <summary> 
        [JsonProperty(PropertyName = "receiving_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceivingCode { get; set; }
        /// <summary> 
        ///产品代码
        /// <summary> 
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        /// <summary> 
        ///数量
        /// <summary> 
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Quantity { get; set; }

    }
}
