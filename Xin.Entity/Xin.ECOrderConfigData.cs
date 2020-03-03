﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/3 13:55:21
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
    public partial class ECOrderConfigData {

        public ECOrderConfigData()
        {
            this.ECSalesOrders = new List<ECSalesOrder>();
            OnCreated();
        }

        /// <summary>
        /// 平台订单ID
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("引用订单id")]
        public virtual string OriginalOrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 平台账号,目前只支持ebay平台
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string OriginalAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 原始订单数据json字符串,目前只支持ebay平台
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(2147483647)]
        public virtual string EbayOrders
        {
            get;
            set;
        }

        /// <summary>
        /// 	原始订单明细数据json字符串,目前只支持ebay平台
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(2147483647)]
        public virtual string EbayOrderDetail
        {
            get;
            set;
        }

        public virtual IList<ECSalesOrder> ECSalesOrders
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
