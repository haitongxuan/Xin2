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
    public partial class ECAsnItem {

        public ECAsnItem()
        {
            this.ProductCosts = new List<ECAsnProductCost>();
            this.WarehouseAtrrs = new List<ECAsnWarehouseAttr>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string ProductBarcode
        {
            get;
            set;
        }

        public virtual int? Quantity
        {
            get;
            set;
        }

        public virtual int? ReceivedQuantity
        {
            get;
            set;
        }

        public virtual int? BoxNo
        {
            get;
            set;
        }

        public virtual int? PutawayQuantity
        {
            get;
            set;
        }

        public virtual decimal? ProductPrice
        {
            get;
            set;
        }

        public virtual ECAsn ECAsn
        {
            get;
            set;
        }

        public virtual IList<ECAsnProductCost> ProductCosts
        {
            get;
            set;
        }

        public virtual IList<ECAsnWarehouseAttr> WarehouseAtrrs
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
