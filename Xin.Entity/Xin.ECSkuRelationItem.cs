﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/7 14:42:32
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
    public partial class ECSkuRelationItem {

        public ECSkuRelationItem()
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

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string PcrProductSku
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string PcrQuantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string PcrPercent
        {
            get;
            set;
        }

        public virtual ECSkuRelation ECSkuRelation
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
