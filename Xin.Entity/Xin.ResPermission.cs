﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/4 15:14:46
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
    public partial class ResPermission : XinVDBaseEntity {

        public ResPermission()
        {
            this.ResRolePermissions = new List<ResRolePermission>();
            this.ResUserPermissions = new List<ResUserPermission>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("资源")]
        public virtual int ResResourceId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DisplayName("权限代码")]
        public virtual string PermissionCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DisplayName("英文名称")]
        public virtual string EnName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DisplayName("中文名称")]
        public virtual string CnName
        {
            get;
            set;
        }

        public virtual ResResource ResResource
        {
            get;
            set;
        }

        public virtual IList<ResRolePermission> ResRolePermissions
        {
            get;
            set;
        }

        public virtual IList<ResUserPermission> ResUserPermissions
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
