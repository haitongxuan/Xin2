﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/8 10:19:13
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
    public partial class ECRepeatCust {

        public ECRepeatCust()
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

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string PlateForm
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string StoreName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string DealMonth
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string Email
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PlateFormCode
        {
            get;
            set;
        }

        public virtual decimal? Amount
        {
            get;
            set;
        }

        public virtual System.DateTime? FkDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string FkType
        {
            get;
            set;
        }

        public virtual System.DateTime? Enterdate
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
