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
    public partial class OMSOrderListOrderFee {

        public OMSOrderListOrderFee()
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
        /// 类型
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Type
        {
            get;
            set;
        }

        /// <summary>
        /// 币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 费用
        /// </summary>
        public virtual double? Amount
        {
            get;
            set;
        }

        public virtual OmsOrderList OmsOrderList
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
