﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/8 13:55:02
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
    public partial class ResRole : XinVDBaseEntity {

        public ResRole()
        {
            this.ResUserRoles = new List<ResUserRole>();
            this.ResRolePermissions = new List<ResRolePermission>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("角色编码")]
        public virtual string RoleCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("角色名称")]
        public virtual string RoleName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(512)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("备注")]
        public virtual string Remark
        {
            get;
            set;
        }

        public virtual IList<ResUserRole> ResUserRoles
        {
            get;
            set;
        }

        public virtual IList<ResRolePermission> ResRolePermissions
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
