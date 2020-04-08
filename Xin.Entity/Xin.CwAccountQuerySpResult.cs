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
    public partial class CwAccountQuerySpResult {

        public CwAccountQuerySpResult()
        {
            OnCreated();
        }

        public virtual string OrderDesc
        {
            get;
            set;
        }

        public virtual System.DateTime? DatePaidPlatform
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string FkType
        {
            get;
            set;
        }

        public virtual System.DateTime? DateWarehouseShipping
        {
            get;
            set;
        }

        public virtual string Status
        {
            get;
            set;
        }

        public virtual string SaleOrderCode
        {
            get;
            set;
        }

        public virtual string RefNo
        {
            get;
            set;
        }

        public virtual string WarehouseOrderCode
        {
            get;
            set;
        }

        public virtual string OrderType
        {
            get;
            set;
        }

        public virtual string CountryName
        {
            get;
            set;
        }

        public virtual string Warehousedesc
        {
            get;
            set;
        }

        public virtual string ProductSku
        {
            get;
            set;
        }

        public virtual string AmazonSKU
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SpUnitPrice
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ZSpUnitPrice
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal DhCost
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ProductNetWeight
        {
            get;
            set;
        }

        public virtual decimal? ZproductNetWeight
        {
            get;
            set;
        }

        public virtual int? Qty
        {
            get;
            set;
        }

        public virtual string Company
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
