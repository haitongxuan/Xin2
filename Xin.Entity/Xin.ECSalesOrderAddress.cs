﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/16 10:57:48
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
    public partial class ECSalesOrderAddress {

        public ECSalesOrderAddress()
        {
            this.ECSalesOrders = new List<ECSalesOrder>();
            OnCreated();
        }

        /// <summary>
        /// 主键
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(11)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string ShippingAddressId
        {
            get;
            set;
        }

        /// <summary>
        /// 收件人名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 公司名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string CompanyName
        {
            get;
            set;
        }

        /// <summary>
        /// 国家二字码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(2)]
        public virtual string CountryCode
        {
            get;
            set;
        }

        /// <summary>
        /// 国家名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public virtual string CountryName
        {
            get;
            set;
        }

        /// <summary>
        /// 城市名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string CityName
        {
            get;
            set;
        }

        /// <summary>
        /// 邮编
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string PostalCode
        {
            get;
            set;
        }

        /// <summary>
        /// 地址第一行
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string Line1
        {
            get;
            set;
        }

        /// <summary>
        /// 地址第二行
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string Line2
        {
            get;
            set;
        }

        /// <summary>
        /// 地址第三行
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string Line3
        {
            get;
            set;
        }

        /// <summary>
        /// 区
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(60)]
        public virtual string District
        {
            get;
            set;
        }

        /// <summary>
        /// 州或省
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string State
        {
            get;
            set;
        }

        /// <summary>
        /// 门牌号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string Doorplate
        {
            get;
            set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual System.DateTime? CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual System.DateTime? UpdateDate
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
