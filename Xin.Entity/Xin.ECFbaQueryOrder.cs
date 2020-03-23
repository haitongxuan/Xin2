﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/23 19:04:54
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
    public partial class ECFbaQueryOrder {

        public ECFbaQueryOrder()
        {
            this.FbaBoxDetail = new List<ECFbaBoxDetail>();
            this.FbaOrderLog = new List<ECFbaLog>();
            this.FbaPack = new List<ECFbaPackBox>();
            this.FbaPackDetail = new List<ECFbaPackDetail>();
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
        public virtual string FbaCode
        {
            get;
            set;
        }

        public virtual string FbaTracking
        {
            get;
            set;
        }

        public virtual string FbaOrderCost
        {
            get;
            set;
        }

        public virtual IList<ECFbaBoxDetail> FbaBoxDetail
        {
            get;
            set;
        }

        public virtual IList<ECFbaLog> FbaOrderLog
        {
            get;
            set;
        }

        public virtual IList<ECFbaPackBox> FbaPack
        {
            get;
            set;
        }

        public virtual IList<ECFbaPackDetail> FbaPackDetail
        {
            get;
            set;
        }

        public virtual ECFbaOrder FbaOrder
        {
            get;
            set;
        }

        public virtual ECFbaBox FbaBox
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}