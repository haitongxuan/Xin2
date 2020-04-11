using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Model
{
   public class EBRmaRefaListReqModel
    {
        /// <summary> 
        ///rma状态 见表1
        /// <summary> 
        [JsonProperty(PropertyName = "rma_status", NullValueHandling = NullValueHandling.Ignore)]
        public string RmaStatus { get; set; }
        /// <summary> 
        ///平台，例如:aliexpress
        /// <summary> 
        [JsonProperty(PropertyName = "platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }
        /// <summary> 
        ///原始订单状态 见表2
        /// <summary> 
        [JsonProperty(PropertyName = "order_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderStatus { get; set; }
        /// <summary> 
        ///买家ID
        /// <summary> 
        [JsonProperty(PropertyName = "buyer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerId { get; set; }
        /// <summary> 
        ///店铺账号
        /// <summary> 
        [JsonProperty(PropertyName = "user_account", NullValueHandling = NullValueHandling.Ignore)]
        public Array UserAccount { get; set; }
        /// <summary> 
        ///原订单号
        /// <summary> 
        [JsonProperty(PropertyName = "backOrderNo", NullValueHandling = NullValueHandling.Ignore)]
        public string BackOrderNo { get; set; }
        /// <summary> 
        ///SKU
        /// <summary> 
        [JsonProperty(PropertyName = "rmaSku", NullValueHandling = NullValueHandling.Ignore)]
        public string RmaSku { get; set; }
        /// <summary> 
        ///重发单号
        /// <summary> 
        [JsonProperty(PropertyName = "refrence_no_platform_in", NullValueHandling = NullValueHandling.Ignore)]
        public string RefrenceNoPlatformIn { get; set; }
        /// <summary> 
        ///rma创建时间始
        /// <summary> 
        [JsonProperty(PropertyName = "createDateFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDateFrom { get; set; }
        /// <summary> 
        ///rma创建时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "createDateEnd", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDateEnd { get; set; }
        /// <summary> 
        ///rma审核时间始
        /// <summary> 
        [JsonProperty(PropertyName = "verifyDateFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? VerifyDateFrom { get; set; }
        /// <summary> 
        ///rma审核时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "verifyDateEnd", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? VerifyDateEnd { get; set; }
        /// <summary> 
        ///原订单创建时间始
        /// <summary> 
        [JsonProperty(PropertyName = "date_create_platform_from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateCreatePlatformFrom { get; set; }
        /// <summary> 
        ///原订单创建时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "date_create_platform_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateCreatePlatformTo { get; set; }
        /// <summary> 
        ///订单付款时间始
        /// <summary> 
        [JsonProperty(PropertyName = "date_paid_platform_from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DatePaidPlatformFrom { get; set; }
        /// <summary> 
        ///订单付款时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "date_paid_platform_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DatePaidPlatformTo { get; set; }
        /// <summary> 
        ///重发单发货时间始
        /// <summary> 
        [JsonProperty(PropertyName = "date_warehouse_shipping_from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateWarehouseShippingFrom { get; set; }
        /// <summary> 
        ///重发单发货时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "date_warehouse_shipping_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateWarehouseShippingTo { get; set; }
        /// <summary> 
        ///页
        /// <summary> 
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
        /// <summary> 
        ///每页数量
        /// <summary> 
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }
    }
}
