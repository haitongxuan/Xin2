using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_DeliveryDetail
    {
        /// <summary> 
        ///出库唯一明细id
        /// <summary> 
        [JsonProperty(PropertyName = "il_id", NullValueHandling = NullValueHandling.Ignore)]
        public string IlId { get; set; }
        /// <summary> 
        ///单据
        /// <summary> 
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///仓库id，仓库-&获取仓库信息接口getWarehouse查询,
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseId { get; set; }
        /// <summary> 
        ///目的仓库id，仓库-&获取仓库信息接口getWarehouse查询
        /// <summary> 
        [JsonProperty(PropertyName = "to_warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ToWarehouseId { get; set; }
        /// <summary> 
        ///仓库code
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_code", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseCode { get; set; }
        /// <summary> 
        ///库位
        /// <summary> 
        [JsonProperty(PropertyName = "lc_code", NullValueHandling = NullValueHandling.Ignore)]
        public string LcCode { get; set; }
        /// <summary> 
        ///创建人ERP OPENAPI-V1：获取基础数据：获取用户列表接口
        /// <summary> 
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        /// <summary> 
        ///出库类型：下方的出库类型映射关系
        /// <summary> 
        [JsonProperty(PropertyName = "application_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationCode { get; set; }
        /// <summary> 
        ///出库类型：0借用,1领用,2不良品,3盘亏,5退货,6良品换货,7次品换良品,8良品转次品,9其他,10线下销售,11组装,12拆分,15按批次拆分,13良品还款,14不良品还款
        /// <summary> 
        [JsonProperty(PropertyName = "cu_type", NullValueHandling = NullValueHandling.Ignore)]
        public int? CuType { get; set; }
        /// <summary> 
        ///产品代码
        /// <summary> 
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        /// <summary> 
        ///产品中文名称
        /// <summary> 
        [JsonProperty(PropertyName = "product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        /// <summary> 
        ///一级品类pc_id：本目录getProductCategory接口
        /// <summary> 
        [JsonProperty(PropertyName = "category1", NullValueHandling = NullValueHandling.Ignore)]
        public int? Category1 { get; set; }
        /// <summary> 
        ///二级品类pc_id：本目录getProductCategory接口
        /// <summary> 
        [JsonProperty(PropertyName = "category2", NullValueHandling = NullValueHandling.Ignore)]
        public int? Category2 { get; set; }
        /// <summary> 
        ///三级品类pc_id：本目录getProductCategory接口
        /// <summary> 
        [JsonProperty(PropertyName = "category3", NullValueHandling = NullValueHandling.Ignore)]
        public int? Category3 { get; set; }
        /// <summary> 
        ///仓库条码
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseProductBarcode { get; set; }
        /// <summary> 
        ///供应商Code,产品-&相关接口getAllSupplier查询
        /// <summary> 
        [JsonProperty(PropertyName = "supplier_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SupplierCode { get; set; }
        /// <summary> 
        ///数量
        /// <summary> 
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Quantity { get; set; }
        /// <summary> 
        ///目标采购价
        /// <summary> 
        [JsonProperty(PropertyName = "org_unit_price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? OrgUnitPrice { get; set; }
        /// <summary> 
        ///单价
        /// <summary> 
        [JsonProperty(PropertyName = "unit_price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? UnitPrice { get; set; }
        /// <summary> 
        ///头程运费
        /// <summary> 
        [JsonProperty(PropertyName = "shipping_fee", NullValueHandling = NullValueHandling.Ignore)]
        public int? ShippingFee { get; set; }
        /// <summary> 
        ///头程关税
        /// <summary> 
        [JsonProperty(PropertyName = "tariff_fee", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TariffFee { get; set; }
        /// <summary> 
        ///采购运费
        /// <summary> 
        [JsonProperty(PropertyName = "unit_purchase_ship_fee", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? UnitPurchaseShipFee { get; set; }
        /// <summary> 
        ///采购税费
        /// <summary> 
        [JsonProperty(PropertyName = "unit_purchase_taxation_fee", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? UnitPurchaseTaxationFee { get; set; }
        /// <summary> 
        ///成本小计：（unit_price+shipping_fee+tariff_fee+unit_purchase_ship_fee+unit_purchase_taxation_fee）quantitycurrency_rate
        /// <summary> 
        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Total { get; set; }
        /// <summary> 
        ///出库时间
        /// <summary> 
        [JsonProperty(PropertyName = "add_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AddTime { get; set; }
        /// <summary> 
        ///系统备注：application_code=SO订单出库会可能存在系统备注
        /// <summary> 
        [JsonProperty(PropertyName = "system_remark", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemRemark { get; set; }
        /// <summary> 
        ///出库单管理备注
        /// <summary> 
        [JsonProperty(PropertyName = "remark", NullValueHandling = NullValueHandling.Ignore)]
        public string Remark { get; set; }
        /// <summary> 
        ///出库单管理产品备注
        /// <summary> 
        [JsonProperty(PropertyName = "product_remark", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductRemark { get; set; }
        /// <summary> 
        ///订单参考号
        /// <summary> 
        [JsonProperty(PropertyName = "ref_no", NullValueHandling = NullValueHandling.Ignore)]
        public string RefNo { get; set; }

    }
}
