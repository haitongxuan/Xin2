using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
   public class EC_RmaRefa
    {
        /// <summary> 
        ///创建时间
        /// <summary> 
        [JsonProperty(PropertyName = "create_date", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateDate { get; set; }
        /// <summary> 
        ///创建人
        /// <summary> 
        [JsonProperty(PropertyName = "create_user", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateUser { get; set; }
        /// <summary> 
        ///备注
        /// <summary> 
        [JsonProperty(PropertyName = "note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }
        /// <summary> 
        ///退件原因
        /// <summary> 
        [JsonProperty(PropertyName = "reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }
        /// <summary> 
        ///卖家账户
        /// <summary> 
        [JsonProperty(PropertyName = "seller_account", NullValueHandling = NullValueHandling.Ignore)]
        public string SellerAccount { get; set; }
        /// <summary> 
        ///买家ID
        /// <summary> 
        [JsonProperty(PropertyName = "buyer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerId { get; set; }
        /// <summary> 
        ///原始订单
        /// <summary> 
        [JsonProperty(PropertyName = "old_order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OldOrderId { get; set; }
        /// <summary> 
        ///原始订单的仓库单号
        /// <summary> 
        [JsonProperty(PropertyName = "old_warehouse_order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OldWarehouseOrderId { get; set; }
        /// <summary> 
        ///重发订单
        /// <summary> 
        [JsonProperty(PropertyName = "refrence_no_platform", NullValueHandling = NullValueHandling.Ignore)]
        public string RefrenceNoPlatform { get; set; }
        /// <summary> 
        ///重发订单的仓库单号
        /// <summary> 
        [JsonProperty(PropertyName = "refrence_no_warehouse", NullValueHandling = NullValueHandling.Ignore)]
        public string RefrenceNoWarehouse { get; set; }
        /// <summary> 
        ///重发订单状态
        /// <summary> 
        [JsonProperty(PropertyName = "order_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderStatus { get; set; }
        /// <summary> 
        ///重发订单国家
        /// <summary> 
        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
        /// <summary> 
        ///SKU
        /// <summary> 
        [JsonProperty(PropertyName = "sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }
        /// <summary> 
        ///数量
        /// <summary> 
        [JsonProperty(PropertyName = "qty", NullValueHandling = NullValueHandling.Ignore)]
        public string Qty { get; set; }
        /// <summary> 
        ///产品名称
        /// <summary> 
        [JsonProperty(PropertyName = "product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        /// <summary> 
        ///SKU单价
        /// <summary> 
        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }
        /// <summary> 
        ///重发SKU
        /// <summary> 
        [JsonProperty(PropertyName = "product_sku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }
        /// <summary> 
        ///PayPal交易号
        /// <summary> 
        [JsonProperty(PropertyName = "trans_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TransId { get; set; }
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
        ///客服备注
        /// <summary> 
        [JsonProperty(PropertyName = "customer_service_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerServiceNote { get; set; }
        /// <summary> 
        ///状态
        /// <summary> 
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

    }
}
