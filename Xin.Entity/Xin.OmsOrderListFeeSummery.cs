﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/6/3 15:50:40
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
    public partial class OmsOrderListFeeSummery {

        public OmsOrderListFeeSummery()
        {
            this.OmsOrderLists = new List<OmsOrderList>();
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
        /// 订单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderCode
        {
            get;
            set;
        }

        /// <summary>
        /// 运输方式
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShippingMethod
        {
            get;
            set;
        }

        /// <summary>
        /// 国家编码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CountryCode
        {
            get;
            set;
        }

        /// <summary>
        /// 订单重量
        /// </summary>
        public virtual double? OrderWeight
        {
            get;
            set;
        }

        /// <summary>
        /// 费用状态:已核账，未核账
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string FeeStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 变更为已核账状态的时间，年月日时分秒
        /// </summary>
        public virtual System.DateTime? FeeTime
        {
            get;
            set;
        }

        /// <summary>
        /// 运费
        /// </summary>
        public virtual double? ShipCost
        {
            get;
            set;
        }

        /// <summary>
        /// 操作费
        /// </summary>
        public virtual double? OpCost
        {
            get;
            set;
        }

        /// <summary>
        /// 燃油附加费
        /// </summary>
        public virtual double? FuelCost
        {
            get;
            set;
        }

        /// <summary>
        /// 挂号费
        /// </summary>
        public virtual double? RegisterCost
        {
            get;
            set;
        }

        /// <summary>
        /// 仓储费
        /// </summary>
        public virtual double? WarehouseCost
        {
            get;
            set;
        }

        /// <summary>
        /// 关税
        /// </summary>
        public virtual double? TariffCost
        {
            get;
            set;
        }

        /// <summary>
        /// 其他费用
        /// </summary>
        public virtual double? IncidentalCost
        {
            get;
            set;
        }

        public virtual IList<OmsOrderList> OmsOrderLists
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
