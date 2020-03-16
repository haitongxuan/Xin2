﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/16 15:28:59
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
    public partial class ECProductCombination {

        public ECProductCombination()
        {
            this.SubProducts = new List<ECSubProduct>();
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
        /// FNSKU
        /// 
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string PcrFnsku
        {
            get;
            set;
        }

        /// <summary>
        /// FBA-ASIN
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string PcrFbaAsin
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库Id，0为全部仓库
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string WarehouseId
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        ///    
        /// </summary>
        public virtual System.DateTime? PcrAddTime
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        ///    
        /// </summary>
        public virtual System.DateTime? PcrUpdateTime
        {
            get;
            set;
        }

        public virtual ECProduct ECProduct
        {
            get;
            set;
        }

        public virtual IList<ECSubProduct> SubProducts
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
