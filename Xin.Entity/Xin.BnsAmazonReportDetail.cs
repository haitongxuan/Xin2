﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/4/29 16:15:21
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
    public partial class BnsAmazonReportDetail {

        public BnsAmazonReportDetail()
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

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PostedDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShipmentFeeType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string DepositDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PromotionType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OtherFeeReasonDescription
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Currency
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string QuantityPurchased
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SettlementId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string MerchantAdjustmentItemId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string FulfillmentId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PromotionId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string MarketplaceName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Sku
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SettlementStartDate
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
        public virtual string DirectPaymentType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string MerchantOrderId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderItemCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SettlementEndDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PriceType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string AdjustmentId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TransactionType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string MerchantOrderItemId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderFeeType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShipmentId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ItemRelatedFeeType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ItemRelatedFeeAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OtherFeeAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string DirectPaymentAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PromotionAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PriceAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string MiscFeeAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OtherAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OrderFeeAmount
        {
            get;
            set;
        }

        public virtual int? AmazonReportOrderId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string TotalAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShipmentFeeAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Store
        {
            get;
            set;
        }

        public virtual BnsAmazonReport BnsAmazonReport
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
