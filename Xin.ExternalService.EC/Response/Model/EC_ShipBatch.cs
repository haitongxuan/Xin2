using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_ShipBatch
    {
        /// <summary> 
        ///订单号
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///入库单号
        /// <summary> 
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///创建时间
        /// <summary> 
        [JsonProperty(PropertyName = "add_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AddTime { get; set; }
        /// <summary> 
        ///预计到货时间
        /// <summary> 
        [JsonProperty(PropertyName = "expected_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpectedDate { get; set; }
        /// <summary> 
        ///跟踪号
        /// <summary> 
        [JsonProperty(PropertyName = "tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingNumber { get; set; }
        /// <summary> 
        ///参考号
        /// <summary> 
        [JsonProperty(PropertyName = "ref_no", NullValueHandling = NullValueHandling.Ignore)]
        public string RefNo { get; set; }
        /// <summary> 
        ///平台账号
        /// <summary> 
        [JsonProperty(PropertyName = "user_account", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAccount { get; set; }
        /// <summary> 
        ///目的仓库
        /// <summary> 
        [JsonProperty(PropertyName = "to_warehouse", NullValueHandling = NullValueHandling.Ignore)]
        public string ToWarehouse { get; set; }
        /// <summary> 
        ///发运仓库
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse", NullValueHandling = NullValueHandling.Ignore)]
        public string Warehouse { get; set; }
        /// <summary> 
        ///运输方式代码
        /// <summary> 
        [JsonProperty(PropertyName = "sm_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCode { get; set; }
        /// <summary> 
        ///运输方式代码中文名称
        /// <summary> 
        [JsonProperty(PropertyName = "sm_name_cn", NullValueHandling = NullValueHandling.Ignore)]
        public string SmNameCn { get; set; }
        /// <summary> 
        ///目的地
        /// <summary> 
        [JsonProperty(PropertyName = "destination", NullValueHandling = NullValueHandling.Ignore)]
        public string Destination { get; set; }
        /// <summary> 
        ///头程费用
        /// <summary> 
        [JsonProperty(PropertyName = "head_freight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal HeadFreight { get; set; }
        /// <summary> 
        ///头程关税
        /// <summary> 
        [JsonProperty(PropertyName = "head_tariff", NullValueHandling = NullValueHandling.Ignore)]
        public decimal HeadTariff { get; set; }
        /// <summary> 
        ///头程费用币种
        /// <summary> 
        [JsonProperty(PropertyName = "cost_currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CostCurrencyCode { get; set; }
        /// <summary> 
        ///头程关税币种
        /// <summary> 
        [JsonProperty(PropertyName = "tariff_currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string TariffCurrencyCode { get; set; }
        /// <summary> 
        ///内件数
        /// <summary> 
        [JsonProperty(PropertyName = "parcel_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string ParcelQuantity { get; set; }
        /// <summary> 
        ///数量（箱）
        /// <summary> 
        [JsonProperty(PropertyName = "box_count", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxCount { get; set; }
        /// <summary> 
        ///金额
        /// <summary> 
        [JsonProperty(PropertyName = "amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Amount { get; set; }
        /// <summary> 
        ///包裹重量（kg）
        /// <summary> 
        [JsonProperty(PropertyName = "so_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string SoWeight { get; set; }
        /// <summary> 
        ///系统重量（kg）
        /// <summary> 
        [JsonProperty(PropertyName = "system_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemWeight { get; set; }
        /// <summary> 
        ///备注
        /// <summary> 
        [JsonProperty(PropertyName = "remark", NullValueHandling = NullValueHandling.Ignore)]
        public string Remark { get; set; }
        /// <summary> 
        ///收件人
        /// <summary> 
        [JsonProperty(PropertyName = "oab_name", NullValueHandling = NullValueHandling.Ignore)]
        public string OabName { get; set; }
        /// <summary> 
        ///联系电话
        /// <summary> 
        [JsonProperty(PropertyName = "oab_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OabPhone { get; set; }
        /// <summary> 
        ///传真
        /// <summary> 
        [JsonProperty(PropertyName = "oab_fax", NullValueHandling = NullValueHandling.Ignore)]
        public string OabFax { get; set; }
        /// <summary> 
        ///收件人公司
        /// <summary> 
        [JsonProperty(PropertyName = "oab_company", NullValueHandling = NullValueHandling.Ignore)]
        public string OabCompany { get; set; }
        /// <summary> 
        ///收件人电子邮件
        /// <summary> 
        [JsonProperty(PropertyName = "oab_email", NullValueHandling = NullValueHandling.Ignore)]
        public string OabEmail { get; set; }
        /// <summary> 
        ///收件人邮编
        /// <summary> 
        [JsonProperty(PropertyName = "oab_postcode", NullValueHandling = NullValueHandling.Ignore)]
        public string OabPostcode { get; set; }
        /// <summary> 
        ///收件人国家
        /// <summary> 
        [JsonProperty(PropertyName = "oab_county", NullValueHandling = NullValueHandling.Ignore)]
        public string OabCounty { get; set; }
        /// <summary> 
        ///收件人州/区域
        /// <summary> 
        [JsonProperty(PropertyName = "oab_state", NullValueHandling = NullValueHandling.Ignore)]
        public string OabState { get; set; }
        /// <summary> 
        ///收件人城市
        /// <summary> 
        [JsonProperty(PropertyName = "oab_city", NullValueHandling = NullValueHandling.Ignore)]
        public string OabCity { get; set; }
        /// <summary> 
        ///收件人地址1
        /// <summary> 
        [JsonProperty(PropertyName = "oab_street_address1", NullValueHandling = NullValueHandling.Ignore)]
        public string OabStreetAddress1 { get; set; }
        /// <summary> 
        ///收件人地址2
        /// <summary> 
        [JsonProperty(PropertyName = "oab_street_address2", NullValueHandling = NullValueHandling.Ignore)]
        public string OabStreetAddress2 { get; set; }
        /// <summary> 
        ///收件人门牌号
        /// <summary> 
        [JsonProperty(PropertyName = "oab_doorplate", NullValueHandling = NullValueHandling.Ignore)]
        public string OabDoorplate { get; set; }
        /// <summary> 
        ///订单产品信息
        /// <summary> 
        [JsonProperty(PropertyName = "product_info", NullValueHandling = NullValueHandling.Ignore)]
        public List<ProductInfo> ProductInfo { get; set; }
        /// <summary> 
        ///装箱单信息
        /// <summary> 
        [JsonProperty(PropertyName = "packing_info", NullValueHandling = NullValueHandling.Ignore)]
        public List<PackingInfo> PackingInfo { get; set; }
    }
    /// <summary>
    /// 订单产品信息
    /// </summary>
    public class ProductInfo
    {
        /// <summary> 
        ///产品名称
        /// <summary> 
        [JsonProperty(PropertyName = "product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        /// <summary> 
        ///产品代码
        /// <summary> 
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        /// <summary> 
        ///三方仓库产品代码
        /// <summary> 
        [JsonProperty(PropertyName = "barcode_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BarcodeCode { get; set; }
        /// <summary> 
        ///产品数量
        /// <summary> 
        [JsonProperty(PropertyName = "op_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string OpQuantity { get; set; }
        /// <summary> 
        ///产品单重（kg）
        /// <summary> 
        [JsonProperty(PropertyName = "product_weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ProductWeight { get; set; }
        /// <summary> 
        ///产品体积（cm³）
        /// <summary> 
        [JsonProperty(PropertyName = "volume", NullValueHandling = NullValueHandling.Ignore)]
        public string Volume { get; set; }
        /// <summary> 
        ///产品付款时间
        /// <summary> 
        [JsonProperty(PropertyName = "op_ref_paydate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? OpRefPaydate { get; set; }
        /// <summary> 
        ///产品总重量（kg，产品单重*产品数量）
        /// <summary> 
        [JsonProperty(PropertyName = "total_weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TotalWeight { get; set; }
    }
    /// <summary>
    /// 装箱单信息
    /// </summary>
    public class PackingInfo
    {
        /// <summary> 
        ///参考号
        /// <summary> 
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///装箱单号
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_code", NullValueHandling = NullValueHandling.Ignore)]
        public string TppCode { get; set; }
        /// <summary> 
        ///产品数量
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? TppQuantity { get; set; }
        /// <summary> 
        ///重量（kg）
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TppWeight { get; set; }
        /// <summary> 
        ///体积（cm³）
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_volume", NullValueHandling = NullValueHandling.Ignore)]
        public string TppVolume { get; set; }
    }
}
