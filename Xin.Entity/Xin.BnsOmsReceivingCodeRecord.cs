﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/16 15:28:59
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
    public partial class BnsOmsReceivingCodeRecord {

        public BnsOmsReceivingCodeRecord()
        {
            this.StopFlag = false;
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        public virtual int? CreateUid
        {
            get;
            set;
        }

        public virtual System.DateTime? CreateDate
        {
            get;
            set;
        }

        public virtual int? WriteUid
        {
            get;
            set;
        }

        public virtual System.DateTime? WriteDate
        {
            get;
            set;
        }

        public virtual bool? StopFlag
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DisplayName("oms入库单号")]
        public virtual string OmsReceivingCode
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("拉取状态，0未拉取，1已拉取")]
        public virtual int? State
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        [System.ComponentModel.DisplayName("信息")]
        public virtual string Message
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
