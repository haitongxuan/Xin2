using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
   public class EC_SkuRelation
    {
        /// <summary>
        /// 平台SKU
        /// </summary>
        [JsonProperty(PropertyName = "product_sku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }

        /// <summary>
        /// 平台账号
        /// </summary>
        [JsonProperty(PropertyName = "user_account", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAccount { get; set; }

        /// <summary>
        /// 对应SKU数据对象
        /// </summary>
        [JsonProperty(PropertyName = "relation", NullValueHandling = NullValueHandling.Ignore)]
        public List<SkuRelations> Relation { get; set; }
    }
    public class SkuRelations {

        /// <summary>
        /// 对应SKU
        /// </summary>
        [JsonProperty(PropertyName = "pcr_product_sku", NullValueHandling = NullValueHandling.Ignore)]
        public string PcrProductSku { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty(PropertyName = "pcr_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string PcrQuantity { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseId { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [JsonProperty(PropertyName = "pcr_percent", NullValueHandling = NullValueHandling.Ignore)]
        public string PcrPercent { get; set; }
    }
    
}
