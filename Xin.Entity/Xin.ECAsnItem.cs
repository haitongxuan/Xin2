﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/16 10:57:48
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
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string ProductSku
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string ProductBarcode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Quantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int ReceivedQuantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int BoxNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int PutawayQuantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ProductPrice
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}