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
        public virtual int Id
        {
            get;
            set;
        }

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

        public virtual string Status
        {
            get;
            set;
        }

        public virtual string SaleOrderCode
        {
            get;
            set;
        }

        public virtual string RefNo
        {
            get;
            set;
        }

        public virtual string WareHouseOrderCode
        {
            get;
            set;
        }

        public virtual string OrderType
        {
            get;
            set;
        }

        public virtual string WareCountryName
        {
            get;
            set;
        }

        public virtual string WareHouseDesc
        {
            get;
            set;
        }

        public virtual string ProductSku
        {
            get;
            set;
        }

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

        public virtual string Company
        {
            get;
            set;
        }

        public virtual string Plateform
        {
            get;
            set;
        }

        public virtual string StoreName
        {
            get;
            set;
        }

        public virtual string PaypalTransactionId
        {
            get;
            set;
        }

        public virtual string Currency
        {
            get;
            set;
        }

        public virtual string LoanType
        {
            get;
            set;
        }

        public virtual string Loandate
        {
            get;
            set;
        }

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

        public virtual string ShipCurrency
        {
            get;
            set;
        }

        public virtual string ShippingMethodNo
        {
            get;
            set;
        }

        public virtual string BuyerName
        {
            get;
            set;
        }

        public virtual string Phone
        {
            get;
            set;
        }

        public virtual string CountryName
        {
            get;
            set;
        }

        public virtual string State
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Adress
        {
            get;
            set;
        }

        public virtual string BuyerMail
        {
            get;
            set;
        }

        public virtual string IsE
        {
            get;
            set;
        }

        public virtual string PersonDevelopname
        {
            get;
            set;
        }

        public virtual string PersonSellername
        {
            get;
            set;
        }

        public virtual string IsFg
        {
            get;
            set;
        }

        public virtual string IsHk
        {
            get;
            set;
        }

        public virtual string IsWg
        {
            get;
            set;
        }

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

        public virtual string BfType
        {
            get;
            set;
        }

        public virtual string BfMemo
        {
            get;
            set;
        }

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

        public virtual string AmazonClaimNo
        {
            get;
            set;
        }

        public virtual string CostRatio
        {
            get;
            set;
        }

        public virtual string ShipRatio
        {
            get;
            set;
        }

        public virtual string NetweightRatio
        {
            get;
            set;
        }

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

        public virtual string SaleType
        {
            get;
            set;
        }

        public virtual string IsFh
        {
            get;
            set;
        }

        public virtual string ProcutCategoryName
        {
            get;
            set;
        }

        public virtual string ProcutCategoryName1
        {
            get;
            set;
        }

        public virtual string ProcutCategoryName2
        {
            get;
            set;
        }

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

        public virtual string GrossRate
        {
            get;
            set;
        }
    }
}
