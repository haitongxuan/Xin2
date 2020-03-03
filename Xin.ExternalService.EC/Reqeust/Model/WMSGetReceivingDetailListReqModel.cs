using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Reqeust.Model
{
    public class WMSGetReceivingDetailListReqModel
    {
        /// <summary> 
        ///入库开始日期： Y-m-d
        /// <summary> 
        [JsonProperty(PropertyName = "dateFor", NullValueHandling = NullValueHandling.Ignore)]
        [JsonRequired]
        public DateTime DateFor { get; set; }
        /// <summary> 
        ///入库截止日期： Y-m-d
        /// <summary> 
        [JsonProperty(PropertyName = "dateTo", NullValueHandling = NullValueHandling.Ignore)]
        [JsonRequired]
        public DateTime DateTo { get; set; }
        /// <summary> 
        ///仓库id数组：默认全部
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_arr", NullValueHandling = NullValueHandling.Ignore)]
        public Array WarehouseArr { get; set; }
        /// <summary> 
        ///仓库code数组(最多1000个)
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_code_arr", NullValueHandling = NullValueHandling.Ignore)]
        public Array WarehouseCodeArr { get; set; }
        /// <summary> 
        ///产品代码
        /// <summary> 
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        /// <summary> 
        ///产品代码，1：模糊查询，0：精确查询
        /// <summary> 
        [JsonProperty(PropertyName = "product_barcode_type", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProductBarcodeType { get; set; }
        /// <summary> 
        ///产品负责人，buyer_id：采购负责人，seller_responsible_id：销售负责人，develop_responsible_id：开发负责人
        /// <summary> 
        [JsonProperty(PropertyName = "operationUserType", NullValueHandling = NullValueHandling.Ignore)]
        public int? OperationUserType { get; set; }
        /// <summary> 
        ///负责人用户id。ERP OPENAPI-V1：获取基础数据：获取用户列表接口
        /// <summary> 
        [JsonProperty(PropertyName = "person", NullValueHandling = NullValueHandling.Ignore)]
        public int? Person { get; set; }
        /// <summary> 
        ///产品品类：本目录getProductCategory接口
        /// <summary> 
        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
        public int? Category { get; set; }
        /// <summary> 
        ///当前页
        /// <summary> 
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
        /// <summary> 
        ///每一页条数，最大1000
        /// <summary> 
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

    }
}
