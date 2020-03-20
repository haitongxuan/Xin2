﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/20 17:13:04
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
    public partial class ECFbaBoxDetail {

        public ECFbaBoxDetail()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int BoxDetailId
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

        public virtual int? ProductId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductBarcode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string GoodsBarcode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductTitle
        {
            get;
            set;
        }

        public virtual decimal? Quantity
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

        public virtual decimal? TransitQty
        {
            get;
            set;
        }

        public virtual decimal? FinalQty
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
