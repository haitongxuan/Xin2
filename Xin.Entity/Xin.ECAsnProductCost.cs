﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
<<<<<<< HEAD
// Code is generated on: 2020/3/16 14:27:07
=======
// Code is generated on: 2020/3/16 10:57:48
>>>>>>> e02549777bf86973191de76df0e15a5ceb859312
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
    public partial class ECAsnProductCost {

        public ECAsnProductCost()
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

        public virtual decimal? TotalCost
        {
            get;
            set;
        }

        public virtual decimal? ShoppingCost
        {
            get;
            set;
        }

        public virtual decimal? CcfCost
        {
            get;
            set;
        }

        public virtual decimal? DtCost
        {
            get;
            set;
        }

        public virtual decimal? OtherCost
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string CustomerCurrency
        {
            get;
            set;
        }

        public virtual decimal? HeadCost
        {
            get;
            set;
        }

        public virtual ECAsnItem ECAsnItem
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
