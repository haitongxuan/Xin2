﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/8 10:19:13
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
    public partial class ECReceivingDetail {

        public ECReceivingDetail()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("入库唯一明细id")]
        public virtual string RlId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DisplayName("单据")]
        public virtual string ReferenceNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("仓库id，仓库->获取仓库信息接口getWarehouse查询,")]
        public virtual string WarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("目的仓库id，仓库->获取仓库信息接口getWarehouse查询")]
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
        public virtual string lcCode
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("创建人ERP OPENAPI-V1：获取基础数据：获取用户列表接口")]
        public virtual int? AddUser
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("确定人ERP OPENAPI-V1：获取基础数据：获取用户列表接口")]
        public virtual int? ReceivingAddUser
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("入库类型：底部有类型映射关系")]
        public virtual string ApplicationCode
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

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("产品单位，EA(单个) KG(公斤) MT(米) CASE(盒) PC(件) SET(套)")]
        public virtual string PuCode
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("是否含有电池，0：否，1：是")]
        public virtual int? ContainBattery
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("是否需要质检，0：否，1：是")]
        public virtual int? ProductIsQc
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("是否为仿制品，0：否，1：是")]
        public virtual int? IsImitation
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("是否存在有效期，0：否，1：是")]
        public virtual int? IsExpDate
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("有效期")]
        public virtual System.DateTime? ExpDate
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
        [System.ComponentModel.DisplayName("供应商Code,产品->相关接口getAllSupplier查询")]
        public virtual string SupplierCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("采购单")]
        public virtual string PoCode
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("采购单审核日期")]
        public virtual System.DateTime? PoRelease
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("是否是采购退货，0：否，1：是")]
        public virtual int? IsReturned
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("收货过多退货数量")]
        public virtual int? ReceivingReturnedQty
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("质检退货数量")]
        public virtual int? QcReturnedQty
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

        [System.ComponentModel.DisplayName("运费")]
        public virtual int? ShippingFee
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("关税")]
        public virtual double? TariffFee
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

        [System.ComponentModel.DisplayName("入库时间")]
        public virtual System.DateTime? AddTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("收货备注")]
        public virtual string ReceivingDescription
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
