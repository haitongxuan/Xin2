using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Model
{
   public class WMSGetTransitBatchNumberReqModel
    {
        /// <summary> 
        ///仓库Id
        /// <summary> 
        [JsonProperty(PropertyName = "warehouseId", NullValueHandling = NullValueHandling.Ignore)]
        public int? WarehouseId { get; set; }
        /// <summary> 
        ///产品SKU
        /// <summary> 
        [JsonProperty(PropertyName = "productSku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }
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
