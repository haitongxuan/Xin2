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
    public partial class ECAsn {

        public ECAsn()
        {
            this.ReceivingCost = new List<ECAsnCost>();
            this.Items = new List<ECAsnItem>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string ReceiveCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string ReferenceNo
        {
            get;
            set;
        }

        public virtual int? IncomeType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string WarehouseCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string TransitWarehouseCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string SmCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string ShippingMethod
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string TrackingNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string ReceivingStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        public virtual string ReceivingDesc
        {
            get;
            set;
        }

        public virtual System.DateTime? EtaDate
        {
            get;
            set;
        }

        public virtual System.DateTime? ReceivingModifyTime
        {
            get;
            set;
        }

        public virtual int? RegionIdLevel0
        {
            get;
            set;
        }

        public virtual int? RegionIdLevel1
        {
            get;
            set;
        }

        public virtual int? RegionIdLevel2
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Street
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Contacter
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string ContactPhone
        {
            get;
            set;
        }

        public virtual int? BoxTotal
        {
            get;
            set;
        }

        public virtual int? SkuTotal
        {
            get;
            set;
        }

        public virtual int? SkuSpecies
        {
            get;
            set;
        }

        public virtual System.DateTime? CalculateFeeTime
        {
            get;
            set;
        }

        public virtual IList<ECAsnCost> ReceivingCost
        {
            get;
            set;
        }

        public virtual IList<ECAsnItem> Items
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
