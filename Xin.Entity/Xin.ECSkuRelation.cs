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
    public partial class ECSkuRelation {

        public ECSkuRelation()
        {
            this.Relation = new List<ECSkuRelationItem>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int RelationId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string UserAccount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        public virtual System.DateTime? CreateTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string WarehouseId
        {
            get;
            set;
        }

        public virtual IList<ECSkuRelationItem> Relation
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
