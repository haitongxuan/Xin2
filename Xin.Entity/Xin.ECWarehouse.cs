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
    public partial class ECWarehouse {

        public ECWarehouse()
        {
            OnCreated();
        }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int WarehouseId
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string WarehouseCode
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string WarehouseDesc
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库类型：0标准，1中转
        /// </summary>
        public virtual int? WarehouseType
        {
            get;
            set;
        }

        /// <summary>
        /// 状态：-1已废弃,0不可用,1可用
        /// </summary>
        public virtual int? WarehouseStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 运营方式：0自营,1第三方
        /// </summary>
        public virtual int? WarehouseVirtual
        {
            get;
            set;
        }

        /// <summary>
        /// 第三方仓储服务
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string WarehouseService
        {
            get;
            set;
        }

        /// <summary>
        /// 是否需要头程（应用于库存成本是否包含头程费用）:0否,1是
        /// </summary>
        public virtual int? IsTransfer
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
        /// 国家ID
        /// </summary>
        public virtual int? CountryId
        {
            get;
            set;
        }

        /// <summary>
        /// 省份
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string State
        {
            get;
            set;
        }

        /// <summary>
        /// 城市
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string City
        {
            get;
            set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string Contacter
        {
            get;
            set;
        }

        /// <summary>
        /// 公司名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Company
        {
            get;
            set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public virtual string PhoneNo
        {
            get;
            set;
        }

        /// <summary>
        /// 地址1
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string StreetAddress1
        {
            get;
            set;
        }

        /// <summary>
        /// 地址2
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string StreetAddress2
        {
            get;
            set;
        }

        /// <summary>
        /// 邮编
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Postcode
        {
            get;
            set;
        }

        /// <summary>
        /// 门牌号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string StreetNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual System.DateTime? WarehouseAddTime
        {
            get;
            set;
        }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public virtual System.DateTime? WarehouseUpdateTime
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
