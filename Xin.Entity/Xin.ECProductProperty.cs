﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/10 13:38:32
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
    public partial class ECProductProperty {

        public ECProductProperty()
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
        /// 属性名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string AttrName
        {
            get;
            set;
        }

        /// <summary>
        /// 属性英文名称
        ///    
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string AttrNameEn
        {
            get;
            set;
        }

        /// <summary>
        /// 属性值
        ///    
        /// </summary>
        public virtual decimal? AttrValue
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
