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
    public partial class ECProductCustomCategory {

        public ECProductCustomCategory()
        {
            OnCreated();
        }

        /// <summary>
        /// 主键
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义分类名称
        ///    
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string PucName
        {
            get;
            set;
        }

        public virtual ECProduct ECProduct
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
