﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/13 15:25:09
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
    public partial class BnsSendDeliverdToEc {

        public BnsSendDeliverdToEc()
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
        /// 运单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string ShippingMethodNo
        {
            get;
            set;
        }

        /// <summary>
        /// 发货时间
        /// </summary>
        public virtual System.DateTime? PlatformShipTime
        {
            get;
            set;
        }

        /// <summary>
        /// 妥投状态
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string DeliveredStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 妥投时间
        /// </summary>
        public virtual System.DateTime? DeliveredTime
        {
            get;
            set;
        }

        /// <summary>
        /// 停留天数
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ResidenceTime
        {
            get;
            set;
        }

        /// <summary>
        /// 运输天数
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TransportationTime
        {
            get;
            set;
        }

        /// <summary>
        /// 物流明细
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(2147483647)]
        public virtual string LogisticsDetails
        {
            get;
            set;
        }

        /// <summary>
        /// 对接商城物流明细
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(2147483647)]
        public virtual string Trackinfo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Ispush
        {
            get;
            set;
        }

        /// <summary>
        /// 是否推入erp
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Status
        {
            get;
            set;
        }

        public virtual ECSalesOrder ECSalesOrder
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
