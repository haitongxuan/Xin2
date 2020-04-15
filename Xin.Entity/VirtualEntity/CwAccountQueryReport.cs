using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
    /// <summary>
    /// 财务报表
    /// </summary>
   public class CwAccountQueryReport
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string OrderDesc
        {
            get;
            set;
        }

        public virtual System.DateTime? DatePaidPlatform
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string FkWay
        {
            get;
            set;
        }

        public virtual System.DateTime? DateWarehouseShipping
        {
            get;
            set;
        }

        public virtual System.DateTime? ShDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Status
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string SaleOrderCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string RefNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string WareHouseOrderCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string OrderType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string WareCountryName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string WareHouseDesc
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string AmazonSKU
        {
            get;
            set;
        }

        public virtual decimal? SpUnitPrice
        {
            get;
            set;
        }

        public virtual decimal? ZSpUnitPrice
        {
            get;
            set;
        }

        public virtual decimal? DhCost
        {
            get;
            set;
        }

        public virtual decimal? ProductNetWeight
        {
            get;
            set;
        }

        public virtual decimal? ZproductNetWeight
        {
            get;
            set;
        }

        public virtual int? Qty
        {
            get;
            set;
        }
        public virtual int? Total
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Company
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Plateform
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string StoreName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PaypalTransactionId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Currency
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string LoanType
        {
            get;
            set;
        }

        public virtual System.DateTime? Loandate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PaypalType
        {
            get;
            set;
        }

        public virtual decimal? Amountpaid
        {
            get;
            set;
        }

        public virtual decimal? AmountpaidItem
        {
            get;
            set;
        }

        public virtual decimal? CompanyAmount
        {
            get;
            set;
        }

        public virtual decimal? DiscountAmount
        {
            get;
            set;
        }

        public virtual decimal? FinalvaluefeeTotal
        {
            get;
            set;
        }

        public virtual decimal? FinalvaluefeeTotalItem
        {
            get;
            set;
        }

        public virtual decimal? AllianceCommission
        {
            get;
            set;
        }

        public virtual decimal? AllianceCommissionItem
        {
            get;
            set;
        }

        public virtual decimal? Tax
        {
            get;
            set;
        }

        public virtual decimal? ShipFee
        {
            get;
            set;
        }

        public virtual decimal? PlatformFeeTotal
        {
            get;
            set;
        }

        public virtual decimal? PlatformFee
        {
            get;
            set;
        }

        public virtual decimal? ProductSales
        {
            get;
            set;
        }

        public virtual decimal? ShippingCredits
        {
            get;
            set;
        }

        public virtual decimal? SellingFees
        {
            get;
            set;
        }

        public virtual decimal? PromotionalRebates
        {
            get;
            set;
        }

        public virtual decimal? FbaFees
        {
            get;
            set;
        }

        public virtual decimal? SalesTaxCollected
        {
            get;
            set;
        }

        public virtual decimal? OtherTransactionFees
        {
            get;
            set;
        }

        public virtual decimal? GiftWrapCredits
        {
            get;
            set;
        }

        public virtual decimal? MarketplaceFacilitatorTax
        {
            get;
            set;
        }

        public virtual decimal? Other
        {
            get;
            set;
        }

        public virtual decimal? Receamount
        {
            get;
            set;
        }

        public virtual decimal? Receamountitem
        {
            get;
            set;
        }

        public virtual decimal? AmountRefund
        {
            get;
            set;
        }

        public virtual decimal? MakeAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShipChannel
        {
            get;
            set;
        }

        public virtual decimal? CostShipFee
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShipCurrency
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShippingMethodNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string BuyerName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Phone
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string CountryName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string State
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Name
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string Adress
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string BuyerMail
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsE
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PersonDevelopname
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PersonSellername
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsFg
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsHk
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsWg
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsCb
        {
            get;
            set;
        }

        public virtual decimal? HeadTariff
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string BfType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string BfMemo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsSm
        {
            get;
            set;
        }

        public virtual decimal? AmazonClaim
        {
            get;
            set;
        }

        public virtual decimal? AmazonClaimCost
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string AmazonClaimNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string CostRatio
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShipRatio
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string NetweightRatio
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PaypalArgue
        {
            get;
            set;
        }

        public virtual decimal? BcAmount
        {
            get;
            set;
        }

        public virtual decimal? TcAmount
        {
            get;
            set;
        }

        public virtual decimal? ByAamount
        {
            get;
            set;
        }

        public virtual decimal? TyAamount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string SaleType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsFh
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName1
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName2
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName3
        {
            get;
            set;
        }

        public virtual decimal? Gross
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string GrossRate
        {
            get;
            set;
        }
    }
}
