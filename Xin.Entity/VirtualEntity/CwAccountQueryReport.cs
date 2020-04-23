using System;
using System.Collections.Generic;
using System.Text;
using Xin.Common.CustomAttribute;

namespace Xin.Entities.VirtualEntity
{
    /// <summary>
    /// 财务报表
    /// </summary>
   public class CwAccountQueryReport
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        [Excel(Header = "行号")]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(500)]
        [Excel(Header = "备注")]
        public virtual string OrderDesc
        {
            get;
            set;
        }

        [Excel(Header = "付款时间", DateTime = "yyyy-MM-dd HH:mm:ss")]
        public virtual System.DateTime? DatePaidPlatform
        {
            get;
            set;
        }

        [Excel(Header = "付款方式")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string FkWay
        {
            get;
            set;
        }

        [Excel(Header = "发货时间", DateTime = "yyyy-MM-dd HH:mm:ss")]
        public virtual System.DateTime? DateWarehouseShipping
        {
            get;
            set;
        }

        [Excel(Header = "收货时间", DateTime = "yyyy-MM-dd HH:mm:ss")]
        public virtual System.DateTime? ShDate
        {
            get;
            set;
        }

        [Excel(Header = "订单状态")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Status
        {
            get;
            set;
        }

        [Excel(Header = "销售单号")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string SaleOrderCode
        {
            get;
            set;
        }

        [Excel(Header = "参考单号")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string RefNo
        {
            get;
            set;
        }

        [Excel(Header = "仓库单号")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string WareHouseOrderCode
        {
            get;
            set;
        }

        [Excel(Header = "订单类型")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string OrderType
        {
            get;
            set;
        }

        [Excel(Header = "仓库位置")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string WareCountryName
        {
            get;
            set;
        }

        [Excel(Header = "发货仓库")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string WareHouseDesc
        {
            get;
            set;
        }

        [Excel(Header = "产品信息")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProductSku
        {
            get;
            set;
        }

        [Excel(Header = "亚马逊商品sku")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string AmazonSKU
        {
            get;
            set;
        }

        [Excel(Header = "商品成本")]
        public virtual decimal? SpUnitPrice
        {
            get;
            set;
        }

        [Excel(Header = "商品总成本")]
        public virtual decimal? ZSpUnitPrice
        {
            get;
            set;
        }

        [Excel(Header = "东恒成本价")]
        public virtual decimal? DhCost
        {
            get;
            set;
        }

        [Excel(Header = "产品重量(净重)")]
        public virtual decimal? ProductNetWeight
        {
            get;
            set;
        }

        [Excel(Header = "产品重量(总重量净重)")]
        public virtual decimal? ZproductNetWeight
        {
            get;
            set;
        }

        [Excel(Header = "产品条数")]
        public virtual int? Qty
        {
            get;
            set;
        }

        [Excel(Header = "公司")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Company
        {
            get;
            set;
        }

        [Excel(Header = "平台")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Plateform
        {
            get;
            set;
        }

        [Excel(Header = "店铺")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string StoreName
        {
            get;
            set;
        }

        [Excel(Header = "交易ID")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PaypalTransactionId
        {
            get;
            set;
        }

        [Excel(Header = "币种")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Currency
        {
            get;
            set;
        }

        [Excel(Header = "放款状态")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string LoanType
        {
            get;
            set;
        }

        [Excel(Header = "放款时间",DateTime = "yyyy-MM-dd HH:mm:ss")]
        public virtual System.DateTime? Loandate
        {
            get;
            set;
        }

        [Excel(Header = "paypal状态")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PaypalType
        {
            get;
            set;
        }

        [Excel(Header = "订单总金额")]
        public virtual decimal? Amountpaid
        {
            get;
            set;
        }

        [Excel(Header = "订单总金额拆分")]
        public virtual decimal? AmountpaidItem
        {
            get;
            set;
        }

        [Excel(Header = "价格(公司未折扣前价格)")]
        public virtual decimal? CompanyAmount
        {
            get;
            set;
        }

        [Excel(Header = "折扣金额")]
        public virtual decimal? DiscountAmount
        {
            get;
            set;
        }

        [Excel(Header = "店铺佣金/手续费")]
        public virtual decimal? FinalvaluefeeTotal
        {
            get;
            set;
        }

        [Excel(Header = "店铺佣金/手续费(拆分)")]
        public virtual decimal? FinalvaluefeeTotalItem
        {
            get;
            set;
        }

        [Excel(Header = "联盟佣金")]
        public virtual decimal? AllianceCommission
        {
            get;
            set;
        }

        [Excel(Header = "联盟佣金（拆分)")]
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

        [Excel(Header = "实收物流费用")]
        public virtual decimal? ShipFee
        {
            get;
            set;
        }

        [Excel(Header = "paypal手续费")]
        public virtual decimal? PlatformFeeTotal
        {
            get;
            set;
        }

        [Excel(Header = "paypal手续费拆分")]
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

        [Excel(Header = "收款金额")]
        public virtual decimal? Receamount
        {
            get;
            set;
        }

        [Excel(Header = "收款金额拆分")]
        public virtual decimal? Receamountitem
        {
            get;
            set;
        }

        [Excel(Header = "退款金额")]
        public virtual decimal? AmountRefund
        {
            get;
            set;
        }

        [Excel(Header = "补偿金额")]
        public virtual decimal? MakeAmount
        {
            get;
            set;
        }

        [Excel(Header = "物流方式")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShipChannel
        {
            get;
            set;
        }

        [Excel(Header = "物流费用")]
        public virtual decimal? CostShipFee
        {
            get;
            set;
        }

        [Excel(Header = "物流费用币种")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShipCurrency
        {
            get;
            set;
        }

        [Excel(Header = "快递单号")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShippingMethodNo
        {
            get;
            set;
        }

        [Excel(Header = "买家名称")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string BuyerName
        {
            get;
            set;
        }

        [Excel(Header = "电话")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Phone
        {
            get;
            set;
        }

        [Excel(Header = "国家")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string CountryName
        {
            get;
            set;
        }

        [Excel(Header = "州")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string State
        {
            get;
            set;
        }

        [Excel(Header = "收货人")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string Name
        {
            get;
            set;
        }

        [Excel(Header = "地址")]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string Adress
        {
            get;
            set;
        }

        [Excel(Header = "邮箱")]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string BuyerMail
        {
            get;
            set;
        }

        [Excel(Header = "是否为E贸易数据")]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsE
        {
            get;
            set;
        }

        [Excel(Header = "设计师")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PersonDevelopname
        {
            get;
            set;
        }

        [Excel(Header = "采购员")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PersonSellername
        {
            get;
            set;
        }

        [Excel(Header = "是否为复购客户")]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsFg
        {
            get;
            set;
        }

        [Excel(Header = "是否对应上回款信息")]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsHk
        {
            get;
            set;
        }

        [Excel(Header = "是否是外购产品")]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsWg
        {
            get;
            set;
        }

        [Excel(Header = "是否成本占比异常")]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsCb
        {
            get;
            set;
        }

        [Excel(Header = "头程关税")]
        public virtual decimal? HeadTariff
        {
            get;
            set;
        }

        [Excel(Header = "补发类型")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string BfType
        {
            get;
            set;
        }

        [Excel(Header = "补发原因")]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public virtual string BfMemo
        {
            get;
            set;
        }

        [Excel(Header = "小产品是否单独销售")]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsSm
        {
            get;
            set;
        }

        [Excel(Header = "亚马逊索赔收入")]
        public virtual decimal? AmazonClaim
        {
            get;
            set;
        }

        [Excel(Header = "亚马逊索赔成本")]
        public virtual decimal? AmazonClaimCost
        {
            get;
            set;
        }

        [Excel(Header = "亚马逊索赔编号")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string AmazonClaimNo
        {
            get;
            set;
        }

        [Excel(Header = "成本占比")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string CostRatio
        {
            get;
            set;
        }

        [Excel(Header = "运费占比")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ShipRatio
        {
            get;
            set;
        }

        [Excel(Header = "净重占比")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string NetweightRatio
        {
            get;
            set;
        }

        [Excel(Header = "paypal是否争议")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string PaypalArgue
        {
            get;
            set;
        }

        [Excel(Header = "补差价")]
        public virtual decimal? BcAmount
        {
            get;
            set;
        }

        [Excel(Header = "退差价")]
        public virtual decimal? TcAmount
        {
            get;
            set;
        }

        [Excel(Header = "补运费")]
        public virtual decimal? ByAamount
        {
            get;
            set;
        }

        [Excel(Header = "退运费")]
        public virtual decimal? TyAamount
        {
            get;
            set;
        }

        [Excel(Header = "销售类型")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string SaleType
        {
            get;
            set;
        }

        [Excel(Header = "是否发货")]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string IsFh
        {
            get;
            set;
        }

        [Excel(Header = "品类")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName
        {
            get;
            set;
        }

        [Excel(Header = "一级品类")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName1
        {
            get;
            set;
        }

        [Excel(Header = "二级品类")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName2
        {
            get;
            set;
        }

        [Excel(Header = "三级品类")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string ProcutCategoryName3
        {
            get;
            set;
        }

        [Excel(Header = "毛利")]
        public virtual decimal? Gross
        {
            get;
            set;
        }

        [Excel(Header = "毛利率")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string GrossRate
        {
            get;
            set;
        }
    }
}
