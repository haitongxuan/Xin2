﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/6 8:46:46
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
    public partial class TCResult {

        public TCResult()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public virtual string TableName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(7000)]
        public virtual string ColumnsList
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(950)]
        public virtual string ParaList
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
