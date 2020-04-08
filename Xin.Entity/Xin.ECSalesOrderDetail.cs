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
    public partial class ECSalesOrderDetail {

        public ECSalesOrderDetail()
        {
            OnCreated();
        }

        /// <summary>
        /// 原系统主键
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string OpId
        {
            get;
            set;
        }

        /// <summary>
        /// 销售sku
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库sku对应关系 ：sku数量费用比例
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(400)]
        public virtual string Sku
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库sku
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string WarehouseSku
        {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal? UnitPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual int? Qty
        {
            get;
            set;
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string ProductTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 产品封面图片
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string Pic
        {
            get;
            set;
        }

        /// <summary>
        /// 产品站点
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string OpSite
        {
            get;
            set;
        }

        /// <summary>
        /// 产品url
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string ProductUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 跟踪明细id，产品明细唯一标识
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string RefItemId
        {
            get;
            set;
        }

        /// <summary>
        /// ebay Item产地,Amazon商品ASIN值
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string OpRefItemLocation
        {
            get;
            set;
        }

        /// <summary>
        /// 单个交易费
        /// </summary>
        public virtual decimal? UnitFinalValueFee
        {
            get;
            set;
        }

        /// <summary>
        /// 单个手续费
        /// </summary>
        public virtual decimal? TransactionPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public virtual System.DateTime? OperTime
        {
            get;
            set;
        }

        public virtual ECSalesOrder ECSalesOrder
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
