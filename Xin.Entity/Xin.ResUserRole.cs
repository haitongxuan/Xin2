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
    public partial class ResUserRole : XinBaseEntity {

        public ResUserRole()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int RoleId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int UserId
        {
            get;
            set;
        }

        public virtual ResRole ResRole
        {
            get;
            set;
        }

        public virtual ResUser ResUser
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
