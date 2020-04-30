﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/29 16:15:21
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
    public partial class ECRmaRefa {

        public ECRmaRefa()
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
        /// 创建时间
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CreateDate
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CreateUser
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Note
        {
            get;
            set;
        }

        /// <summary>
        /// 退件原因
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Reason
        {
            get;
            set;
        }

        /// <summary>
        /// 卖家账户
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SellerAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 买家ID
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string BuyerId
        {
            get;
            set;
        }

        /// <summary>
        /// 原始订单
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OldOrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 原始订单的仓库单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OldWarehouseOrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 重发订单
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string RefrenceNoPlatform
        {
            get;
            set;
        }

        /// <summary>
        /// 重发订单的仓库单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string RefrenceNoWarehouse
        {
            get;
            set;
        }

        /// <summary>
        /// 重发订单状态
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 重发订单国家
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Country
        {
            get;
            set;
        }

        /// <summary>
        /// SKU
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Sku
        {
            get;
            set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Qty
        {
            get;
            set;
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductTitle
        {
            get;
            set;
        }

        /// <summary>
        /// SKU单价
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Price
        {
            get;
            set;
        }

        /// <summary>
        /// 重发SKU
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        /// <summary>
        /// PayPal交易号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TransId
        {
            get;
            set;
        }

        /// <summary>
        /// 交易金额
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string AmountPaid
        {
            get;
            set;
        }

        /// <summary>
        /// 销售额
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string AmountOrder
        {
            get;
            set;
        }

        /// <summary>
        /// 币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Currency
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string WarehousId
        {
            get;
            set;
        }

        /// <summary>
        /// 运输方式
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShippingMethod
        {
            get;
            set;
        }

        /// <summary>
        /// 客服备注
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CustomerServiceNote
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Status
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}