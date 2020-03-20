﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/20 17:13:04
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
    public partial class ResResource : XinVDBaseEntity {

        public ResResource()
        {
            this.ResPermissions = new List<ResPermission>();
            OnCreated();
        }

        public virtual string TypeName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("资源代码")]
        public virtual string ResourceCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("英文名称")]
        public virtual string EnName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DisplayName("中文名称")]
        public virtual string CnName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("更改人")]
        public virtual int WriteUid
        {
            get;
            set;
        }

        public virtual IList<ResPermission> ResPermissions
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
