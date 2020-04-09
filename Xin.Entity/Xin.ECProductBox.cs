﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/8 13:55:02
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
    public partial class ECProductBox {

        public ECProductBox()
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
        /// 名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string BoxName
        {
            get;
            set;
        }

        /// <summary>
        /// 英文名称
        ///    
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string BoxNameEn
        {
            get;
            set;
        }

        /// <summary>
        /// 宽
        /// </summary>
        public virtual decimal? BoxWidth
        {
            get;
            set;
        }

        /// <summary>
        /// 高
        /// </summary>
        public virtual decimal? BoxHeight
        {
            get;
            set;
        }

        /// <summary>
        /// 重量
        /// </summary>
        public virtual decimal? BoxWeight
        {
            get;
            set;
        }

        /// <summary>
        /// 长
        /// </summary>
        public virtual decimal? BoxLength
        {
            get;
            set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual int? Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// 箱规状态： 0不可用 1可用
        ///    
        /// </summary>
        public virtual int? BoxStatus
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
