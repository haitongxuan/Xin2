﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/9 14:17:27
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
    public partial class ECOrderInfoPackageInfo {

        public ECOrderInfoPackageInfo()
        {
            this.ECOrderInfoPackageLists = new List<ECOrderInfoPackageList>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string WarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpuCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CustomerCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CustomerId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpBarcode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpActionType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpQuantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpCost
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

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpLength
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpNameEn
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpHeight
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpWidth
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpWeight
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpAddTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpUpdateTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PpPath
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoPackageList> ECOrderInfoPackageLists
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}