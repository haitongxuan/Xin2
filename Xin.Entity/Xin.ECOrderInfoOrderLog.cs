﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/6/3 15:50:40
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
    public partial class ECOrderInfoOrderLog {

        public ECOrderInfoOrderLog()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string OlId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OlType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OrderStatusFrom
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OrderStatusTo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OlAddTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string UserId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OlIp
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OlComments
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string UserName
        {
            get;
            set;
        }

        public virtual ECOrderInfo ECOrderInfo
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
