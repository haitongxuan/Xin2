﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/28 8:41:23
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
    public partial class DingClassify {

        public DingClassify()
        {
            this.DingNews = new List<DingNew>();
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
        /// 分类
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Remark
        {
            get;
            set;
        }

        public virtual IList<DingNew> DingNews
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
