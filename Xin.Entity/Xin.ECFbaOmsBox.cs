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
    public partial class ECFbaOmsBox {

        public ECFbaOmsBox()
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

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string BoxCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string BoxNum
        {
            get;
            set;
        }

        public virtual decimal? BoxLength
        {
            get;
            set;
        }

        public virtual decimal? BoxWidth
        {
            get;
            set;
        }

        public virtual decimal? BoxHeight
        {
            get;
            set;
        }

        public virtual decimal? BoxWeight
        {
            get;
            set;
        }

        public virtual decimal? ProductQty
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
