﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/7 11:24:10
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
    public partial class ResOperateLog : XinBaseEntity {

        public ResOperateLog()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("操作表名称")]
        public virtual string TableName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("日志类型(0：正常，1：异常)")]
        public virtual int Type
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("描述")]
        public virtual string Describe
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
