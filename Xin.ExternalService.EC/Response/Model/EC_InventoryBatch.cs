using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_InventoryBatch
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
        ///库位
        /// <summary> 
        [JsonProperty(PropertyName = "lcCode", NullValueHandling = NullValueHandling.Ignore)]
        public string LcCode { get; set; }
        /// <summary> 
        ///可用数量
        /// <summary> 
        [JsonProperty(PropertyName = "ibQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? IbQuantity { get; set; }
        /// <summary> 
        ///待出数量
        /// <summary> 
        [JsonProperty(PropertyName = "outQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? OutQuantity { get; set; }
        /// <summary> 
        ///参考单号
        /// <summary> 
        [JsonProperty(PropertyName = "referenceNo", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///入库单号
        /// <summary> 
        [JsonProperty(PropertyName = "roCode", NullValueHandling = NullValueHandling.Ignore)]
        public string RoCode { get; set; }
        /// <summary> 
        ///采购单号
        /// <summary> 
        [JsonProperty(PropertyName = "poCode", NullValueHandling = NullValueHandling.Ignore)]
        public string PoCode { get; set; }
        /// <summary> 
        ///状态 0已用完/不可用 1可用
        /// <summary> 
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public int? Status { get; set; }
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
        ///上架时间
        /// <summary> 
        [JsonProperty(PropertyName = "fifoTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FifoTime { get; set; }
        /// <summary> 
        ///更新时间
        /// <summary> 
        [JsonProperty(PropertyName = "updateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateTime { get; set; }
        /// <summary> 
        ///是否需要报关 0否 1是
        /// <summary> 
        [JsonProperty(PropertyName = "isNeedDeclare", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsNeedDeclare { get; set; }

    }
}
