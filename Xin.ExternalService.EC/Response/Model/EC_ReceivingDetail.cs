using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_ReceivingDetail
    {
        /// <summary> 
        ///入库唯一明细id
        /// <summary> 
        [JsonProperty(PropertyName = "rl_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RlId { get; set; }
        /// <summary> 
        ///单据
        /// <summary> 
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///仓库id，仓库->获取仓库信息接口getWarehouse查询,
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseId { get; set; }
        /// <summary> 
        ///目的仓库id，仓库->获取仓库信息接口getWarehouse查询
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
        [JsonProperty(PropertyName = "add_user", NullValueHandling = NullValueHandling.Ignore)]
        public int? AddUser { get; set; }
        /// <summary> 
        ///确定人ERP OPENAPI-V1：获取基础数据：获取用户列表接口
        /// <summary> 
        [JsonProperty(PropertyName = "receiving_add_user", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReceivingAddUser { get; set; }
        /// <summary> 
        ///入库类型：底部有类型映射关系
        /// <summary> 
        [JsonProperty(PropertyName = "application_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationCode { get; set; }
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
        ///产品单位，EA(单个) KG(公斤) MT(米) CASE(盒) PC(件) SET(套)
        /// <summary> 
        [JsonProperty(PropertyName = "pu_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PuCode { get; set; }
        /// <summary> 
        ///是否含有电池，0：否，1：是
        /// <summary> 
        [JsonProperty(PropertyName = "contain_battery", NullValueHandling = NullValueHandling.Ignore)]
        public int? ContainBattery { get; set; }
        /// <summary> 
        ///是否需要质检，0：否，1：是
        /// <summary> 
        [JsonProperty(PropertyName = "product_is_qc", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProductIsQc { get; set; }
        /// <summary> 
        ///是否为仿制品，0：否，1：是
        /// <summary> 
        [JsonProperty(PropertyName = "is_imitation", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsImitation { get; set; }
        /// <summary> 
        ///是否存在有效期，0：否，1：是
        /// <summary> 
        [JsonProperty(PropertyName = "is_exp_date", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsExpDate { get; set; }
        /// <summary> 
        ///有效期
        /// <summary> 
        [JsonProperty(PropertyName = "exp_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpDate { get; set; }
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
        ///供应商Code,产品->相关接口getAllSupplier查询
        /// <summary> 
        [JsonProperty(PropertyName = "supplier_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SupplierCode { get; set; }
        /// <summary> 
        ///采购单
        /// <summary> 
        [JsonProperty(PropertyName = "po_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PoCode { get; set; }
        /// <summary> 
        ///采购单审核日期
        /// <summary> 
        [JsonProperty(PropertyName = "po_release", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PoRelease { get; set; }
        /// <summary> 
        ///是否是采购退货，0：否，1：是
        /// <summary> 
        [JsonProperty(PropertyName = "is_returned", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsReturned { get; set; }
        /// <summary> 
        ///收货过多退货数量
        /// <summary> 
        [JsonProperty(PropertyName = "receiving_returned_qty", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReceivingReturnedQty { get; set; }
        /// <summary> 
        ///质检退货数量
        /// <summary> 
        [JsonProperty(PropertyName = "qc_returned_qty", NullValueHandling = NullValueHandling.Ignore)]
        public int? QcReturnedQty { get; set; }
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
        ///运费
        /// <summary> 
        [JsonProperty(PropertyName = "shipping_fee", NullValueHandling = NullValueHandling.Ignore)]
        public int? ShippingFee { get; set; }
        /// <summary> 
        ///关税
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
        ///入库时间
        /// <summary> 
        [JsonProperty(PropertyName = "add_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AddTime { get; set; }
        /// <summary> 
        ///收货备注
        /// <summary> 
        [JsonProperty(PropertyName = "receiving_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceivingDescription { get; set; }

    }
}
