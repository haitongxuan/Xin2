﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/6 17:25:48
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
    public partial class ECFbaOrder {

        public ECFbaOrder()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string FbaCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string AmazonShipment
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string AmazonReference
        {
            get;
            set;
        }

        public virtual int? SmType
        {
            get;
            set;
        }

        public virtual int? FbaType
        {
            get;
            set;
        }

        public virtual int? StockType
        {
            get;
            set;
        }

        public virtual int? FbaStatus
        {
            get;
            set;
        }

        public virtual int? ExceptionStatus
        {
            get;
            set;
        }

        public virtual int? BackStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CompanyCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ExceptionInfo
        {
            get;
            set;
        }

        public virtual int? ScId
        {
            get;
            set;
        }

        public virtual int? LabelStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TrackingNumber
        {
            get;
            set;
        }

        public virtual int? TransitWarehouseId
        {
            get;
            set;
        }

        public virtual int? ToWarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SmCode
        {
            get;
            set;
        }

        public virtual int? FbaId
        {
            get;
            set;
        }

        public virtual int? WarehouseId
        {
            get;
            set;
        }

        public virtual int? NextWarehouseId
        {
            get;
            set;
        }

        public virtual int? IsInsurance
        {
            get;
            set;
        }

        public virtual decimal? InsuranceValue
        {
            get;
            set;
        }

        public virtual int? BoxTotal
        {
            get;
            set;
        }

        public virtual int? ProductTotal
        {
            get;
            set;
        }

        public virtual decimal? WeightTotal
        {
            get;
            set;
        }

        public virtual decimal? ReckonWeight
        {
            get;
            set;
        }

        public virtual decimal? CurrencyAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CurrencyCode
        {
            get;
            set;
        }

        public virtual int? PayStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PayTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string FbaRemarks
        {
            get;
            set;
        }

        public virtual int? CreateSite
        {
            get;
            set;
        }

        public virtual int? CreateUserId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CreateTime
        {
            get;
            set;
        }

        public virtual int? UpdateUserId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string UpdateTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TransitReceiptTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TransitSendTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ToReceiptTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ToSendTime
        {
            get;
            set;
        }

        public virtual int? SyncWmsStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SyncWmsTime
        {
            get;
            set;
        }

        public virtual ECFbaQueryOrder ECFbaQueryOrder
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
