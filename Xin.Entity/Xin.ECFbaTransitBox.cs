﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/6/2 13:01:32
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
    public partial class ECFbaTransitBox {

        public ECFbaTransitBox()
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

        public virtual int? WarehouseId
        {
            get;
            set;
        }

        public virtual int? BoxId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string BoxCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string FbaCode
        {
            get;
            set;
        }

        public virtual decimal? Length
        {
            get;
            set;
        }

        public virtual decimal? Width
        {
            get;
            set;
        }

        public virtual decimal? Height
        {
            get;
            set;
        }

        public virtual decimal? Weight
        {
            get;
            set;
        }

        public virtual int? ProQty
        {
            get;
            set;
        }

        public virtual int? MeasureUserId
        {
            get;
            set;
        }

        public virtual System.DateTime? MeasureTime
        {
            get;
            set;
        }

        public virtual System.DateTime? ArriveTime
        {
            get;
            set;
        }

        public virtual System.DateTime? OutTime
        {
            get;
            set;
        }

        public virtual int? ReceiptStatus
        {
            get;
            set;
        }

        public virtual int? MeasureStatus
        {
            get;
            set;
        }

        public virtual int? ExceptionStatus
        {
            get;
            set;
        }

        public virtual int? ExceptionConfirm
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

        public virtual System.DateTime? UpdateTime
        {
            get;
            set;
        }

        public virtual ECFbaBox ECFbaBox
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
