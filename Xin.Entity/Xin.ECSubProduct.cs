﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/7 11:24:10
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
    public partial class ECSubProduct {

        public ECSubProduct()
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
        /// 组合子产品SKU
        ///    
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string PcrProductSku
        {
            get;
            set;
        }

        /// <summary>
        /// 组合子产品数量
        ///    
        /// </summary>
        public virtual int? PcrQty
        {
            get;
            set;
        }

        public virtual ECProductCombination ECProductCombination
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
