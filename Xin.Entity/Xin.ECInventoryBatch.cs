﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/21 17:08:34
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
    public partial class ECInventoryBatch {

        public ECInventoryBatch()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public virtual int? WarehouseId
        {
            get;
            set;
        }

        /// <summary>
        /// 产品SKU代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        /// <summary>
        /// 库位
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string LcCode
        {
            get;
            set;
        }

        /// <summary>
        /// 可用数量
        /// </summary>
        public virtual int? IbQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// 待出数量
        /// </summary>
        public virtual int? OutQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// 参考单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ReferenceNo
        {
            get;
            set;
        }

        /// <summary>
        /// 入库单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string RoCode
        {
            get;
            set;
        }

        /// <summary>
        /// 采购单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PoCode
        {
            get;
            set;
        }

        /// <summary>
        /// 状态 0已用完/不可用 1可用
        /// </summary>
        public virtual int? Status
        {
            get;
            set;
        }

        /// <summary>
        /// 锁状态 0无 1盘点锁 2借领用锁
        /// </summary>
        public virtual int? HoldStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 库存类型 0标准 1不良品
        /// </summary>
        public virtual int? Type
        {
            get;
            set;
        }

        /// <summary>
        /// 上架时间
        /// </summary>
        public virtual System.DateTime? FifoTime
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual System.DateTime? UpdateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 是否需要报关 0否 1是
        /// </summary>
        public virtual int? IsNeedDeclare
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
