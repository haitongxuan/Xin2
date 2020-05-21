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
    public partial class ECTransitBatchNumber {

        public ECTransitBatchNumber()
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

        /// <summary>
        /// 仓库Id
        /// </summary>
        public virtual int? WarehouseId
        {
            get;
            set;
        }

        /// <summary>
        /// 产品SKU代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        /// <summary>
        /// 入库单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string RoCode
        {
            get;
            set;
        }

        /// <summary>
        /// 在途数量
        /// </summary>
        public virtual int? TransitBatchNumber
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
