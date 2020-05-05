﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/5 11:21:18
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
    public partial class BnsPaypalTransactionDetailsCartInfo {

        public BnsPaypalTransactionDetailsCartInfo()
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
        /// 产品编号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemCode
        {
            get;
            set;
        }

        /// <summary>
        /// 产品姓名
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemName
        {
            get;
            set;
        }

        /// <summary>
        /// 产品描述
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemDescription
        {
            get;
            set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// 单价币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemUnitPriceCurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemUnitPriceValue
        {
            get;
            set;
        }

        /// <summary>
        /// 总价币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemAmountCurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 总价
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsItemAmountValue
        {
            get;
            set;
        }

        /// <summary>
        /// 税额币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsTaxAmountTaxAmountCurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 税额
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsTaxAmountTaxAmountValue
        {
            get;
            set;
        }

        /// <summary>
        /// 总额币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsTotalItemAmountCurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 总额
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsTotalItemAmountValue
        {
            get;
            set;
        }

        /// <summary>
        /// 发票号码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CartInfoItemDetailsInvoiceNumber
        {
            get;
            set;
        }

        public virtual BnsPaypalTransactionDetail BnsPaypalTransactionDetail
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
