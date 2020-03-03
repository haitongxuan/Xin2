using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Model
{
    public class EBGetRmaRefundListReqModel
    {
        /// <summary> 
        ///退款状态 1:待审核 2:已审核 3:已退款 4:退款失败
        /// <summary> 
        [JsonProperty(PropertyName = "ex_rma_status", NullValueHandling = NullValueHandling.Ignore)]
        public string ExRmaStatus { get; set; }
        /// <summary> 
        ///退款方式 1:系统 2:标记退款
        /// <summary> 
        [JsonProperty(PropertyName = "ex_rma_refund_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ExRmaRefundType { get; set; }
        /// <summary> 
        ///数据来源 value:name aliexpress:Aliexpress aliexpresscn:1688 amazon:Amazon b2c:B2C cdiscount:Cdiscount ebay:eBay lazada:Lazada m2c:M2C
        /// <summary> 
        [JsonProperty(PropertyName = "ex_rma_data_source", NullValueHandling = NullValueHandling.Ignore)]
        public string ExRmaDataSource { get; set; }
        /// <summary> 
        ///店铺账号
        /// <summary> 
        [JsonProperty(PropertyName = "ex_rma_user_account", NullValueHandling = NullValueHandling.Ignore)]
        public Array ExRmaUserAccount { get; set; }
        /// <summary> 
        ///仓库退件 1:存在 0:暂无
        /// <summary> 
        [JsonProperty(PropertyName = "ro_code_exist", NullValueHandling = NullValueHandling.Ignore)]
        public string RoCodeExist { get; set; }
        /// <summary> 
        ///创建人
        /// <summary> 
        [JsonProperty(PropertyName = "rma_creator_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RmaCreatorId { get; set; }
        /// <summary> 
        ///站点
        /// <summary> 
        [JsonProperty(PropertyName = "site", NullValueHandling = NullValueHandling.Ignore)]
        public string Site { get; set; }
        /// <summary> 
        ///创建时间首
        /// <summary> 
        [JsonProperty(PropertyName = "create_date_form", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDateForm { get; set; }
        /// <summary> 
        ///创建时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "create_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDateTo { get; set; }
        /// <summary> 
        ///审核时间首
        /// <summary> 
        [JsonProperty(PropertyName = "verify_date_form", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? VerifyDateForm { get; set; }
        /// <summary> 
        ///审核时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "verify_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? VerifyDateTo { get; set; }
        /// <summary> 
        ///付款时间首
        /// <summary> 
        [JsonProperty(PropertyName = "paid_date_form", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PaidDateForm { get; set; }
        /// <summary> 
        ///付款时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "paid_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PaidDateTo { get; set; }
        /// <summary> 
        ///退款时间首
        /// <summary> 
        [JsonProperty(PropertyName = "refund_date_form", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? RefundDateForm { get; set; }
        /// <summary> 
        ///退款时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "refund_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? RefundDateTo { get; set; }
        /// <summary> 
        ///出库时间首
        /// <summary> 
        [JsonProperty(PropertyName = "date_warehouse_shipping_from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateWarehouseShippingFrom { get; set; }
        /// <summary> 
        ///出库时间尾
        /// <summary> 
        [JsonProperty(PropertyName = "date_warehouse_shipping_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateWarehouseShippingTo { get; set; }
        /// <summary> 
        ///1:转换汇率 0:不转换
        /// <summary> 
        [JsonProperty(PropertyName = "is_conver", NullValueHandling = NullValueHandling.Ignore)]
        public string IsConver { get; set; }
        /// <summary> 
        /// 页
        /// <summary> 
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
        /// <summary> 
        /// 每页数量
        /// <summary> 
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

    }
}
