using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_RmaRefund
    {
        /// <summary> 
        ///创建时间
        /// <summary> 
        [JsonProperty(PropertyName = "create_date", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateDate { get; set; }
        /// <summary> 
        ///参考号
        /// <summary> 
        [JsonProperty(PropertyName = "ref_no", NullValueHandling = NullValueHandling.Ignore)]
        public string RefNo { get; set; }
        /// <summary> 
        ///仓库单号
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_ref_no", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseRefNo { get; set; }
        /// <summary> 
        ///退款原因
        /// <summary> 
        [JsonProperty(PropertyName = "reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }
        /// <summary> 
        ///PayPal退款交易号
        /// <summary> 
        [JsonProperty(PropertyName = "trans_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TransId { get; set; }
        /// <summary> 
        ///创建人
        /// <summary> 
        [JsonProperty(PropertyName = "create_user", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateUser { get; set; }
        /// <summary> 
        ///退款备注
        /// <summary> 
        [JsonProperty(PropertyName = "note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }
        /// <summary> 
        ///财务备注
        /// <summary> 
        [JsonProperty(PropertyName = "financial_note", NullValueHandling = NullValueHandling.Ignore)]
        public string FinancialNote { get; set; }
        /// <summary> 
        ///审核时间
        /// <summary> 
        [JsonProperty(PropertyName = "verify_date", NullValueHandling = NullValueHandling.Ignore)]
        public string VerifyDate { get; set; }
        /// <summary> 
        ///审核人
        /// <summary> 
        [JsonProperty(PropertyName = "verify_user", NullValueHandling = NullValueHandling.Ignore)]
        public string VerifyUser { get; set; }
        /// <summary> 
        ///账户
        /// <summary> 
        [JsonProperty(PropertyName = "user_account", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAccount { get; set; }
        /// <summary> 
        ///账号别名
        /// <summary> 
        [JsonProperty(PropertyName = "user_account_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAccountName { get; set; }
        /// <summary> 
        ///建立退款订单
        /// <summary> 
        [JsonProperty(PropertyName = "refrence_no_platform", NullValueHandling = NullValueHandling.Ignore)]
        public string RefrenceNoPlatform { get; set; }
        /// <summary> 
        ///实际退款订单
        /// <summary> 
        [JsonProperty(PropertyName = "rma_refrence_no_platform", NullValueHandling = NullValueHandling.Ignore)]
        public string RmaRefrenceNoPlatform { get; set; }
        /// <summary> 
        ///付款时间
        /// <summary> 
        [JsonProperty(PropertyName = "paid_date", NullValueHandling = NullValueHandling.Ignore)]
        public string PaidDate { get; set; }
        /// <summary> 
        ///出库时间
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_ship_date", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseShipDate { get; set; }
        /// <summary> 
        ///国家
        /// <summary> 
        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
        /// <summary> 
        ///站点
        /// <summary> 
        [JsonProperty(PropertyName = "site", NullValueHandling = NullValueHandling.Ignore)]
        public string Site { get; set; }
        /// <summary> 
        ///仓库
        /// <summary> 
        [JsonProperty(PropertyName = "warehous_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehousId { get; set; }
        /// <summary> 
        ///运输方式
        /// <summary> 
        [JsonProperty(PropertyName = "shipping_method", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingMethod { get; set; }
        /// <summary> 
        ///系统备注
        /// <summary> 
        [JsonProperty(PropertyName = "operator_note", NullValueHandling = NullValueHandling.Ignore)]
        public string OperatorNote { get; set; }
        /// <summary> 
        ///客服备注
        /// <summary> 
        [JsonProperty(PropertyName = "customer_service_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerServiceNote { get; set; }
        /// <summary> 
        ///SKU
        /// <summary> 
        [JsonProperty(PropertyName = "product_sku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }
        /// <summary> 
        ///销售负责人
        /// <summary> 
        [JsonProperty(PropertyName = "sale_user", NullValueHandling = NullValueHandling.Ignore)]
        public string SaleUser { get; set; }
        /// <summary> 
        ///产品名称
        /// <summary> 
        [JsonProperty(PropertyName = "product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        /// <summary> 
        ///退款数量
        /// <summary> 
        [JsonProperty(PropertyName = "qty", NullValueHandling = NullValueHandling.Ignore)]
        public string Qty { get; set; }
        /// <summary> 
        ///一级品类
        /// <summary> 
        [JsonProperty(PropertyName = "pc_like", NullValueHandling = NullValueHandling.Ignore)]
        public string PcLike { get; set; }
        /// <summary> 
        ///品类名称
        /// <summary> 
        [JsonProperty(PropertyName = "pc_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PcName { get; set; }
        /// <summary> 
        ///paypal交易号
        /// <summary> 
        [JsonProperty(PropertyName = "pay_ref_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PayRefId { get; set; }
        /// <summary> 
        ///退款类型
        /// <summary> 
        [JsonProperty(PropertyName = "refund_type", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundType { get; set; }
        /// <summary> 
        ///退款金额
        /// <summary> 
        [JsonProperty(PropertyName = "amount_refund", NullValueHandling = NullValueHandling.Ignore)]
        public string AmountRefund { get; set; }
        /// <summary> 
        ///交易金额
        /// <summary> 
        [JsonProperty(PropertyName = "amount_paid", NullValueHandling = NullValueHandling.Ignore)]
        public string AmountPaid { get; set; }
        /// <summary> 
        ///销售额
        /// <summary> 
        [JsonProperty(PropertyName = "amount_order", NullValueHandling = NullValueHandling.Ignore)]
        public string AmountOrder { get; set; }
        /// <summary> 
        ///币种
        /// <summary> 
        [JsonProperty(PropertyName = "currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }
        /// <summary> 
        ///买家ID
        /// <summary> 
        [JsonProperty(PropertyName = "buyer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerId { get; set; }
        /// <summary> 
        ///退款时间
        /// <summary> 
        [JsonProperty(PropertyName = "refund_date", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundDate { get; set; }
        /// <summary> 
        ///退款状态
        /// <summary> 
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        /// <summary> 
        ///退款方式
        /// <summary> 
        [JsonProperty(PropertyName = "refund_step", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundStep { get; set; }
        /// <summary> 
        ///数据来源
        /// <summary> 
        [JsonProperty(PropertyName = "refund_data_source", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundDataSource { get; set; }
        /// <summary> 
        ///同步信息
        /// <summary> 
        [JsonProperty(PropertyName = "sync_message", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncMessage { get; set; }

    }
}
