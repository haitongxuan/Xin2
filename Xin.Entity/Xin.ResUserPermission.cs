﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/31 15:53:34
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
    public partial class ResUserPermission : XinBaseEntity {

        public ResUserPermission()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("主键")]
        public virtual int UserId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int PermissionId
        {
            get;
            set;
        }

        public virtual ResUser ResUser
        {
            get;
            set;
        }

        public virtual ResPermission ResPermission
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
