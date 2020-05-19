﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/19 17:42:02
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
    public partial class ECOrderInfo {

        public ECOrderInfo()
        {
            this.opNode = new List<ECOrderInfoOpNode>();
            this.order = new List<ECOrderInfoOrder>();
            this.orderLog = new List<ECOrderInfoOrderLog>();
            this.product = new List<ECOrderInfoProduct>();
            this.odaTypeArr = new List<ECOrderInfoOdaTypeArr>();
            this.orderAddress = new List<ECOrderInfoAdress>();
            this.packingList = new List<ECOrderInfoPackageList>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string OrderCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderLog
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OpNode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Product
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Order
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderAddress
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PackingList
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string BbServiceProviderCurrency
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderTrack
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SyncConfirmShipStatusArr
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OdaTypeArr
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoOpNode> opNode
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoOrder> order
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoOrderLog> orderLog
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoProduct> product
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoOdaTypeArr> odaTypeArr
        {
            get;
            set;
        }

        public virtual ECOrderInfoOrderStatu orderStatus
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoAdress> orderAddress
        {
            get;
            set;
        }

        public virtual IList<ECOrderInfoPackageList> packingList
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
