﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/12 16:33:41
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
    public partial class RepBaseBrandStock {

        public RepBaseBrandStock()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int ECWarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SingleSKu
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Qty
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
