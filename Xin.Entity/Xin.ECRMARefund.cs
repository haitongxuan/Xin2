﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/7 14:11:12
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
    public partial class ECRMARefund {

        public ECRMARefund()
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

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("创建时间")]
        public virtual string CreateDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("参考号	")]
        public virtual string RefNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("仓库单号")]
        public virtual string WarehouseRefNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("退款原因")]
        public virtual string Reason
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("PayPal退款交易号")]
        public virtual string TransId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("创建人")]
        public virtual string CreateUser
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("退款备注")]
        public virtual string Note
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("财务备注")]
        public virtual string FinancialNote
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("审核时间")]
        public virtual string VerifyDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("审核人")]
        public virtual string VerifyUser
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("账户")]
        public virtual string UserAccount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("账号别名")]
        public virtual string UserAccountName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("建立退款订单")]
        public virtual string RefrenceNoPlatform
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("实际退款订单")]
        public virtual string RmaRefrenceNoPlatform
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("出库时间")]
        public virtual string WarehouseShipDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("国家")]
        public virtual string Country
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("站点")]
        public virtual string Site
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("仓库")]
        public virtual string WarehousId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("运输方式")]
        public virtual string ShippingMethod
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("系统备注")]
        public virtual string OperatorNote
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("客服备注")]
        public virtual string CustomerServiceNote
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("SKU")]
        public virtual string ProductSku
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("销售负责人")]
        public virtual string SaleUser
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("产品名称")]
        public virtual string ProductTitle
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("退款数量")]
        public virtual string Qty
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("一级品类")]
        public virtual string PcLike
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("品类名称")]
        public virtual string PcName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("paypal交易号")]
        public virtual string PayRefId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("退款类型")]
        public virtual string RefundType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("退款金额")]
        public virtual string AmountRefund
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("交易金额")]
        public virtual string AmountPaid
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("销售额")]
        public virtual string AmountOrder
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("币种 ")]
        public virtual string Currency
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("买家ID")]
        public virtual string BuyerId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("退款时间")]
        public virtual string RefundDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("退款状态")]
        public virtual string Status
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("退款方式")]
        public virtual string RefundStep
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.ComponentModel.DisplayName("数据来源")]
        public virtual string RefundDataSource
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        [System.ComponentModel.DisplayName("同步信息")]
        public virtual string SyncMessage
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
