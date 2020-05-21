﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/21 17:08:34
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
    public partial class ResUser : XinVDBaseEntity {

        public ResUser()
        {
            this.ResUserRoles = new List<ResUserRole>();
            this.ResUserPermissions = new List<ResUserPermission>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("用户名")]
        public virtual string UserName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("用户编号")]
        public virtual string UserCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DisplayName("真实名称")]
        public virtual string RealName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("用户密码")]
        public virtual string UserPwd
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("部门主键")]
        public virtual int DeptId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("管理员标记")]
        public virtual bool AdminFlag
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DisplayName("电话号码")]
        public virtual string Phone
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = @"Email is not a well-formed email address.")]
        [System.ComponentModel.DisplayName("电子邮箱")]
        public virtual string Email
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(512)]
        [System.ComponentModel.DisplayName("说明")]
        public virtual string Remark
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(512)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("头像URL")]
        public virtual string HeadUrl
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("登入时间")]
        public virtual System.DateTime LoginDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DisplayName("加密字段")]
        public virtual string Salt
        {
            get;
            set;
        }

        public new ResDepartment ResDepartment
        {
            get;
            set;
        }

        public virtual IList<ResUserRole> ResUserRoles
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
