using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Request.Model
{
    public class GetOrderListRequestModel
    {
        /// <summary> 
        ///每页数据长度，最大值100
        /// <summary> 
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }
        /// <summary> 
        ///当前页
        /// <summary> 
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
        /// <summary> 
        ///订单号
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///订单状态 C:待发货审核 W:待发货 D:已发货 H:暂存 N:异常订单 P:问题件 X:废弃
        /// <summary> 
        [JsonProperty(PropertyName = "order_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderStatus { get; set; }
        /// <summary> 
        ///多个订单号,数组格式
        /// <summary> 
        [JsonProperty(PropertyName = "order_code_arr", NullValueHandling = NullValueHandling.Ignore)]
        public Object OrderCodeArr { get; set; }
        /// <summary> 
        ///运输方式代码
        /// <summary> 
        [JsonProperty(PropertyName = "shipping_method", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingMethod { get; set; }
        /// <summary> 
        ///订单创建开始时间， 格式YYYY-MM-DD HH:II:SS 订单号传值时，该参数无效
        /// <summary> 
        [JsonProperty(PropertyName = "create_date_from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDateFrom { get; set; }
        /// <summary> 
        ///订单创建结束时间， 格式YYYY-MM-DD HH:II:SS 订单号传值时，该参数无效
        /// <summary> 
        [JsonProperty(PropertyName = "create_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateDateTo { get; set; }
        /// <summary> 
        ///订单修改开始时间， 格式YYYY-MM-DD HH:II:SS 订单号传值时，该参数无效
        /// <summary> 
        [JsonProperty(PropertyName = "modify_date_from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModifyDateFrom { get; set; }
        /// <summary> 
        ///订单修改结束时间， 格式YYYY-MM-DD HH:II:SS 订单号传值时，该参数无效
        /// <summary> 
        [JsonProperty(PropertyName = "modify_date_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModifyDateTo { get; set; }

    }
}
