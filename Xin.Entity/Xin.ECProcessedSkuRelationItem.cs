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
    public partial class ECProcessedSkuRelationItem {

        public ECProcessedSkuRelationItem()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int RelationItemId
        {
            get;
            set;
        }

        public virtual int? RelationId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string StoreProductCategory
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string PcrProductSku
        {
            get;
            set;
        }

        public virtual int? PcrQuantity
        {
            get;
            set;
        }

        public virtual decimal? PcrPercent
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string Density
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string HandArea
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string Style
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string Size
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string ProductCategory
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public virtual string ProductType
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
