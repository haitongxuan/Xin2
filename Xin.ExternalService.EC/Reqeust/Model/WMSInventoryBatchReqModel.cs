using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Model
{
    public class WMSInventoryBatchReqModel
    {
        /// <summary> 
        ///产品SKU
        /// <summary> 
        [JsonProperty(PropertyName = "productSku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }
        /// <summary> 
        ///产品SKU模糊查询
        /// <summary> 
        [JsonProperty(PropertyName = "productSkuLike", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSkuLike { get; set; }
        /// <summary> 
        ///产品名称
        /// <summary> 
        [JsonProperty(PropertyName = "productTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        /// <summary> 
        ///产品名称模糊查询
        /// <summary> 
        [JsonProperty(PropertyName = "productTitleLike", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitleLike { get; set; }
        /// <summary> 
        ///锁状态 0无 1盘点锁 2借领用锁
        /// <summary> 
        [JsonProperty(PropertyName = "holdStatus", NullValueHandling = NullValueHandling.Ignore)]
        public int? HoldStatus { get; set; }
        /// <summary> 
        ///库存类型 0标准 1不良品
        /// <summary> 
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public int? Type { get; set; }
        /// <summary> 
        ///仓库Id
        /// <summary> 
        [JsonProperty(PropertyName = "warehouseId", NullValueHandling = NullValueHandling.Ignore)]
        public int? WarehouseId { get; set; }
        /// <summary> 
        ///上架时间-开始时间
        /// <summary> 
        [JsonProperty(PropertyName = "fifoTimeFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FifoTimeFrom { get; set; }
        /// <summary> 
        ///上架时间-截止时间
        /// <summary> 
        [JsonProperty(PropertyName = "fifoTimeTo", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FifoTimeTo { get; set; }
        /// <summary> 
        ///当前页
        /// <summary> 
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
        /// <summary> 
        ///每页条数，最大1000
        /// <summary> 
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }
    }
}
