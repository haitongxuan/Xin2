using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Model
{
   public class WMSShipBatchReqModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty(PropertyName = "orderCode", NullValueHandling = NullValueHandling.Ignore)]

        public string OrderCode { get; set; }

        /// <summary>
        /// 创建时间（大于）
        /// </summary>
        [JsonProperty(PropertyName = "dateFor", NullValueHandling = NullValueHandling.Ignore)]

        public string DateFor { get; set; }

        /// <summary>
        /// 创建时间（小于）
        /// </summary>
        [JsonProperty(PropertyName = "dateTo", NullValueHandling = NullValueHandling.Ignore)]

        public string DateTo { get; set; }


        /// <summary>
        /// 页码
        /// </summary>
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]

        public string Page { get; set; }

        /// <summary>
        /// 每页数量，默认20，最大50
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]

        public string PageSize { get; set; }
    }
}
