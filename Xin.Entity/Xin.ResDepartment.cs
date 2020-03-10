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
    public partial class ResDepartment : XinVDBaseEntity {

        public ResDepartment()
        {
            this.ChildrenDept = new List<ResDepartment>();
            this.ResUsers = new List<ResUser>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("部门编号")]
        public virtual string DeptCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("部门名称")]
        public virtual string DeptName
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

        [System.ComponentModel.DisplayName("上级部门")]
        public virtual int? ParentId
        {
            get;
            set;
        }

        public virtual IList<ResDepartment> ChildrenDept
        {
            get;
            set;
        }

        public virtual ResDepartment ParentDept
        {
            get;
            set;
        }

        public new IList<ResUser> ResUsers
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
