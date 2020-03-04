using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Model
{
    public class EBGetSkuRelationReqModel
    {
        /// <summary>
        /// 页码
        /// </summary>
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonProperty(PropertyName = "condition", NullValueHandling = NullValueHandling.Ignore)]
        public RelationCondition Condition { get; set; }
    }
    public class RelationCondition
    {

        /// <summary>
        /// 平台账号
        /// </summary>
        [JsonProperty(PropertyName = "userAccount", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAccount { get; set; }
        /// <summary>
        /// 平台sku
        /// </summary>
        [JsonProperty(PropertyName = "productSku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [JsonProperty(PropertyName = "warehouseId", NullValueHandling = NullValueHandling.Ignore)]

        public string WarehouseId { get; set; }

        /// <summary>
        /// 对应SKU
        /// </summary>
        [JsonProperty(PropertyName = "pcrProductSku", NullValueHandling = NullValueHandling.Ignore)]

        public string PcrProductSku { get; set; }

        /// <summary>
        /// 创建开始时间
        /// </summary>
        [JsonProperty(PropertyName = "addTimeStart", NullValueHandling = NullValueHandling.Ignore)]

        public string AddTimeStart { get; set; }

        /// <summary>
        /// 创建结束时间
        /// </summary>
        [JsonProperty(PropertyName = "addTimeEnd", NullValueHandling = NullValueHandling.Ignore)]

        public string AddTimeEnd { get; set; }

    }
}
