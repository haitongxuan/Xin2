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
    public partial class ECOrderInfoPackageList {

        public ECOrderInfoPackageList()
        {
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string TppId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppSn
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ReferenceNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TptCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SmCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string WarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ToWarehouseId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppCreaterId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppCompleteId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppQuantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppLength
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppWidth
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppHeight
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppWeight
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppNetWeight
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppIsverify
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppReceivingStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppIsbattery
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppAddTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppUpdateTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppExcuteTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TppPutawayStatus
        {
            get;
            set;
        }

        public virtual ECOrderInfo ECOrderInfo
        {
            get;
            set;
        }

        public virtual ECOrderInfoPackageInfo ECOrderInfoPackageInfo
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
