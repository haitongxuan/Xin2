using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
   public class EC_TransitBatchNumber
    {
        /// <summary> 
        ///仓库Id
        /// <summary> 
        [JsonProperty(PropertyName = "warehouseId", NullValueHandling = NullValueHandling.Ignore)]
        public int? WarehouseId { get; set; }
        /// <summary> 
        ///产品SKU代码
        /// <summary> 
        [JsonProperty(PropertyName = "productSku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }
        /// <summary> 
        ///入库单号
        /// <summary> 
        [JsonProperty(PropertyName = "roCode", NullValueHandling = NullValueHandling.Ignore)]
        public string RoCode { get; set; }
        /// <summary> 
        ///在途数量
        /// <summary> 
        [JsonProperty(PropertyName = "transitBatchNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? TransitBatchNumber { get; set; }

    }
}
