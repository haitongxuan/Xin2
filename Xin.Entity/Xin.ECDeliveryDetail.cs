﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
<<<<<<< HEAD
// Code is generated on: 2020/3/16 14:27:07
=======
// Code is generated on: 2020/3/16 10:57:48
>>>>>>> e02549777bf86973191de76df0e15a5ceb859312
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;

namespace Xin.Entities
{
    public partial class ECDeliveryDetail {

        public ECDeliveryDetail()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("出库唯一明细id")]
        public virtual string IlId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("单据")]
        public virtual string ReferenceNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("仓库id，仓库-&获取仓库信息接口getWarehouse查询,")]
        public virtual string WarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("目的仓库id，仓库-&获取仓库信息接口getWarehouse查询")]
        public virtual string ToWarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("仓库code")]
        public virtual string WarehouseCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("库位")]
        public virtual string IcCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("创建人ERP OPENAPI-V1：获取基础数据：获取用户列表接口")]
        public virtual string UserId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("出库类型：下方的出库类型映射关系")]
        public virtual string ApplicationCode
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("出库类型：0借用,1领用,2不良品,3盘亏,5退货,6良品换货,7次品换良品,8良品转次品,9其他,10线下销售,11组装,12拆分,15按批次拆分,13良品还款,14不良品还款")]
        public virtual int? CuType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("产品代码")]
        public virtual string ProductBarcode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("产品中文名称")]
        public virtual string ProductTitle
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("一级品类pc_id：本目录getProductCategory接口")]
        public virtual int? Category1
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("二级品类pc_id：本目录getProductCategory接口")]
        public virtual int? Category2
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("三级品类pc_id：本目录getProductCategory接口")]
        public virtual int? Category3
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("仓库条码")]
        public virtual string WarehouseProductBarcode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("供应商Code,产品-&相关接口getAllSupplier查询")]
        public virtual string SupplierCode
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("数量")]
        public virtual int? Quantity
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("目标采购价")]
        public virtual double? OrgUnitPrice
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("单价")]
        public virtual double? UnitPrice
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("头程运费")]
        public virtual int? ShippingFee
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("头程关税")]
        public virtual double? Tariff_Fee
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("采购运费")]
        public virtual double? UnitPurchaseShipFee
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("采购税费")]
        public virtual double? UnitPurchaseTaxationFee
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("成本小计：（unit_price+shipping_fee+tariff_fee+unit_purchase_ship_fee+unit_purchase_taxation_fee）quantitycurrency_rate")]
        public virtual double? Total
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("出库时间")]
        public virtual System.DateTime? AddTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("系统备注：application_code=SO订单出库会可能存在系统备注")]
        public virtual string SystemRemark
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("出库单管理备注")]
        public virtual string Remark
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("出库单管理产品备注")]
        public virtual string ProductRemark
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("订单参考号")]
        public virtual string RefNo
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
