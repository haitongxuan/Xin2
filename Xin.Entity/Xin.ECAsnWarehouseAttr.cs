﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/8 10:19:13
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
    public partial class ECAsnWarehouseAttr {

        public ECAsnWarehouseAttr()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        public virtual decimal? ProductLength
        {
            get;
            set;
        }

        public virtual decimal? ProductWidth
        {
            get;
            set;
        }

        public virtual decimal? ProductHeight
        {
            get;
            set;
        }

        public virtual decimal? ProductWeight
        {
            get;
            set;
        }

        public virtual ECAsnItem ECAsnItem
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
