using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;
using Xin.Repository;

namespace Xin.Service.Context
{
    public partial class XinDBContext : DbContext, IEntityContext
    {

        private void VirtuleMappingCreate(ModelBuilder modelBuilder)
        {
            this.SingleProductSellMapping(modelBuilder);
            this.SingleSalesAnalysisMapping(modelBuilder);
            this.UsTagTypeInventoryMapping(modelBuilder);
            this.ChannelLevelSalesCountMapping(modelBuilder);
            this.TotalSaleMapping(modelBuilder);
            this.HairWeftStyleSaleMapping(modelBuilder);
            this.SaleOrderDetailMapping(modelBuilder);
            this.OddMinusSaleMapping(modelBuilder);
            this.WavingBlockMapping(modelBuilder);
            this.HeadgearDensityMapping(modelBuilder);
            this.ListStringModelMapping(modelBuilder);
            this.PlateformLevelMapping(modelBuilder);
            this.CwAccountQueryReportMapping(modelBuilder);
            this.ResultTableMapping(modelBuilder);
            this.EcHeadTripLineMapping(modelBuilder);
            this.OrderCostTotalMapping(modelBuilder);
            this.SkuSaleQueryMapping(modelBuilder);

        }

        private void SkuSaleQueryMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkuSaleQueryReport>().Property<string>(@"storeName").HasColumnName(@"storeName").ValueGeneratedNever();
            modelBuilder.Entity<SkuSaleQueryReport>().Property<string>(@"refNo").HasColumnName(@"refNo").ValueGeneratedNever();
            modelBuilder.Entity<SkuSaleQueryReport>().Property<string>(@"sku").HasColumnName(@"sku").ValueGeneratedNever(); 
            modelBuilder.Entity<SkuSaleQueryReport>().Property<int?>(@"qty").HasColumnName(@"qty").ValueGeneratedNever();
            modelBuilder.Entity<SkuSaleQueryReport>().HasKey(@"id");
        }

        private void OrderCostTotalMapping(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<OrderCostTotalReport>().Property<string>(@"storeName").HasColumnName(@"storeName").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<string>(@"currency").HasColumnName(@"currency").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<int?>(@"orderQty").HasColumnName(@"orderQty").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<int?>(@"productQty").HasColumnName(@"productQty").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<decimal?>(@"shipFee").HasColumnName(@"shipFee").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<decimal?>(@"total").HasColumnName(@"total").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<decimal?>(@"cost").HasColumnName(@"cost").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<string>(@"plateform").HasColumnName(@"plateform").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().Property<string>(@"grossmargin").HasColumnName(@"grossmargin").ValueGeneratedNever();
            modelBuilder.Entity<OrderCostTotalReport>().HasKey(@"id");
        }

        private void ResultTableMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<string>(x => x.Sku).HasColumnName(@"Sku").HasColumnType(@"varchar(255)").ValueGeneratedNever().HasMaxLength(255);
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<string>(x => x.CategoryParent).HasColumnName(@"CategoryParent").HasColumnType(@"varchar(255)").ValueGeneratedNever().HasMaxLength(255);
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<string>(x => x.Category).HasColumnName(@"Category").HasColumnType(@"varchar(255)").ValueGeneratedNever().HasMaxLength(255);
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<string>(x => x.Picture).HasColumnName(@"Picture").HasColumnType(@"varchar(255)").ValueGeneratedNever().HasMaxLength(255);
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<string>(x => x.Name).HasColumnName(@"Name").HasColumnType(@"varchar(255)").ValueGeneratedNever().HasMaxLength(255);
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.UnicePeriodQty).HasColumnName(@"UnicePeriodQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.UncieToUsQty).HasColumnName(@"UncieToUsQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.DhToUsQty).HasColumnName(@"DhToUsQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.UniceSaleQty).HasColumnName(@"UniceSaleQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.UsTransAmazingQty).HasColumnName(@"UsTransAmazingQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.OffLineQty).HasColumnName(@"OffLineQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.UniceEndingQty).HasColumnName(@"UniceEndingQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.UsEndingQty).HasColumnName(@"UsEndingQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().Property<int?>(x => x.NomalEnndingQty).HasColumnName(@"NomalEnndingQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<UsUiceNomalSkuQtyReport>().HasKey(@"Id");
        }
        private void CwAccountQueryReportMapping(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.OrderCostRatio).HasColumnName(@"OrderCostRatio").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<int>(x => x.Id).HasColumnName(@"id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.OrderDesc).HasColumnName(@"orderDesc").HasColumnType(@"varchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<CwAccountQueryReport>().Property<System.DateTime?>(x => x.DatePaidPlatform).HasColumnName(@"DatePaidPlatform").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.FkWay).HasColumnName(@"FkWay").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<System.DateTime?>(x => x.DateWarehouseShipping).HasColumnName(@"DateWarehouseShipping").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<System.DateTime?>(x => x.ShDate).HasColumnName(@"ShDate").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Status).HasColumnName(@"Status").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.SaleOrderCode).HasColumnName(@"SaleOrderCode").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.RefNo).HasColumnName(@"RefNo").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.WareHouseOrderCode).HasColumnName(@"WareHouseOrderCode").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.OrderType).HasColumnName(@"OrderType").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.WareCountryName).HasColumnName(@"WareCountryName").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.WareHouseDesc).HasColumnName(@"WareHouseDesc").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ProductSku).HasColumnName(@"ProductSku").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.AmazonSKU).HasColumnName(@"AmazonSKU").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.SpUnitPrice).HasColumnName(@"SpUnitPrice").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.ZSpUnitPrice).HasColumnName(@"ZSpUnitPrice").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.DhCost).HasColumnName(@"DhCost").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.ProductNetWeight).HasColumnName(@"ProductNetWeight").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.ZproductNetWeight).HasColumnName(@"ZproductNetWeight").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<int?>(x => x.Qty).HasColumnName(@"Qty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Company).HasColumnName(@"Company").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Plateform).HasColumnName(@"Plateform").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.StoreName).HasColumnName(@"StoreName").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.PaypalTransactionId).HasColumnName(@"PaypalTransactionId").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Currency).HasColumnName(@"Currency").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.LoanType).HasColumnName(@"LoanType").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<System.DateTime?>(x => x.Loandate).HasColumnName(@"Loandate").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.PaypalType).HasColumnName(@"PaypalType").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Amountpaid).HasColumnName(@"amountpaid").HasColumnType(@"varchar(4000)").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.AmountpaidItem).HasColumnName(@"amountpaidItem").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.CompanyAmount).HasColumnName(@"CompanyAmount").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.DiscountAmount).HasColumnName(@"DiscountAmount").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.FinalvaluefeeTotal).HasColumnName(@"finalvaluefeeTotal").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.FinalvaluefeeTotalItem).HasColumnName(@"finalvaluefeeTotalItem").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.AllianceCommission).HasColumnName(@"AllianceCommission").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.AllianceCommissionItem).HasColumnName(@"AllianceCommissionItem").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.Tax).HasColumnName(@"tax").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.ShipFee).HasColumnName(@"ShipFee").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.PlatformFeeTotal).HasColumnName(@"PlatformFeeTotal").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.PlatformFee).HasColumnName(@"PlatformFee").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.ProductSales).HasColumnName(@"ProductSales").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.ShippingCredits).HasColumnName(@"ShippingCredits").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.SellingFees).HasColumnName(@"SellingFees").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.PromotionalRebates).HasColumnName(@"PromotionalRebates").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.FbaFees).HasColumnName(@"FbaFees").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.SalesTaxCollected).HasColumnName(@"SalesTaxCollected").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.OtherTransactionFees).HasColumnName(@"OtherTransactionFees").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.GiftWrapCredits).HasColumnName(@"GiftWrapCredits").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.MarketplaceFacilitatorTax).HasColumnName(@"MarketplaceFacilitatorTax").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.Other).HasColumnName(@"Other").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Receamount).HasColumnName(@"Receamount").HasColumnType(@"varchar(4000)").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.Receamountitem).HasColumnName(@"Receamountitem").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.AmountRefund).HasColumnName(@"AmountRefund").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.MakeAmount).HasColumnName(@"MakeAmount").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ShipChannel).HasColumnName(@"ShipChannel").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.CostShipFee).HasColumnName(@"CostShipFee").HasColumnType(@"varchar(4000)").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ShipCurrency).HasColumnName(@"ShipCurrency").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ShippingMethodNo).HasColumnName(@"shippingMethodNo").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.BuyerName).HasColumnName(@"buyerName").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Phone).HasColumnName(@"Phone").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.CountryName).HasColumnName(@"CountryName").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.State).HasColumnName(@"State").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Name).HasColumnName(@"Name").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.Adress).HasColumnName(@"Adress").HasColumnType(@"varchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.BuyerMail).HasColumnName(@"BuyerMail").HasColumnType(@"varchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.IsE).HasColumnName(@"isE").HasColumnType(@"varchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.PersonDevelopname).HasColumnName(@"PersonDevelopname").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.PersonSellername).HasColumnName(@"PersonSellername").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.IsFg).HasColumnName(@"IsFg").HasColumnType(@"varchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.IsHk).HasColumnName(@"IsHk").HasColumnType(@"varchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.IsWg).HasColumnName(@"IsWg").HasColumnType(@"varchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.IsCb).HasColumnName(@"IsCb").HasColumnType(@"varchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.HeadTariff).HasColumnName(@"HeadTariff").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.BfType).HasColumnName(@"BfType").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.BfMemo).HasColumnName(@"BfMemo").HasColumnType(@"varchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.IsSm).HasColumnName(@"IsSm").HasColumnType(@"varchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.AmazonClaim).HasColumnName(@"AmazonClaim").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.AmazonClaimCost).HasColumnName(@"AmazonClaimCost").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.AmazonClaimNo).HasColumnName(@"AmazonClaimNo").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.CostRatio).HasColumnName(@"CostRatio").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ShipRatio).HasColumnName(@"ShipRatio").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.NetweightRatio).HasColumnName(@"NetweightRatio").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.PaypalArgue).HasColumnName(@"PaypalArgue").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.BcAmount).HasColumnName(@"BcAmount").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.TcAmount).HasColumnName(@"TcAmount").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.ByAamount).HasColumnName(@"ByAamount").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.TyAamount).HasColumnName(@"TyAamount").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.SaleType).HasColumnName(@"SaleType").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.IsFh).HasColumnName(@"IsFh").HasColumnType(@"varchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ProcutCategoryName).HasColumnName(@"ProcutCategoryName").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ProcutCategoryName1).HasColumnName(@"ProcutCategoryName1").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ProcutCategoryName2).HasColumnName(@"ProcutCategoryName2").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.ProcutCategoryName3).HasColumnName(@"ProcutCategoryName3").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().Property<decimal?>(x => x.Gross).HasColumnName(@"Gross").HasColumnType(@"money").ValueGeneratedNever();
            modelBuilder.Entity<CwAccountQueryReport>().Property<string>(x => x.GrossRate).HasColumnName(@"GrossRate").HasColumnType(@"varchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<CwAccountQueryReport>().HasKey(@"Id");
        }
        private void PlateformLevelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"AliexpressQty").HasColumnName(@"AliexpressQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"AmazonQty").HasColumnName(@"AmazonQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"EbayQty").HasColumnName(@"EbayQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"ShopifyQty").HasColumnName(@"ShopifyQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"OtherQty").HasColumnName(@"OtherQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"AfricanmallQty").HasColumnName(@"AfricanmallQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"JuliahairQty").HasColumnName(@"JuliahairQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"NadulamallQty").HasColumnName(@"NadulamallQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"UnicemallQty").HasColumnName(@"UnicemallQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"BfmallQty").HasColumnName(@"BfmallQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"UnicefrQty").HasColumnName(@"UnicefrQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"ZyQty").HasColumnName(@"ZyQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"ZyItemQty").HasColumnName(@"ZyItemQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().Property<int>(@"ZQty").HasColumnName(@"ZQty").ValueGeneratedNever();
            modelBuilder.Entity<PlateformLevel>().HasKey(@"SaleType");
        }

        public virtual DbSet<ECHeadTripLine> ECHeadTripLines { get; set; }
        public virtual DbSet<CwAccountQueryReport> CwAccountQueryReports
        {
            get;
            set;
        }
        public virtual DbSet<PlateformLevel> PlateformLevels { get; set; }
        public virtual DbSet<UsUiceNomalSkuQtyReport> UsUiceNomalSkuQtyReports { get; set; }
        public virtual DbSet<OrderCostTotalReport> OrderCostTotalReports { get; set; }

        public virtual DbSet<SkuSaleQueryReport> SkuSaleQueryReports { get; set; }
        public virtual DbSet<WavingBlock> WavingBlocks { get; set; }
        public virtual DbSet<HeadgearDensity> HeadgearDensitys { get; set; }
        public virtual DbSet<SingleProductSell> SingleProductSells { get; set; }
        public virtual DbSet<SingleSalesAnalysis> SingleSalesAnalyses { get; set; }
        public virtual DbSet<UsTagTypeInventory> UsTagTypeInventories { get; set; }
        public virtual DbSet<ChannelLevelSalesCount> ChannelLevelSalesCounts { get; set; }
        public virtual DbSet<HairWeftStyleSale> HairWeftStyleSales { get; set; }
        public virtual DbSet<OddMinusSale> OddMinusSale { get; set; }
        public virtual DbSet<TotalSale> TotalSales { get; set; }
        public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }

        private void HeadgearDensityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeadgearDensity>().Property<string>(@"Style").HasColumnName(@"Style").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density360130").HasColumnName(@"Density360130").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density136250").HasColumnName(@"Density136250").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density360150").HasColumnName(@"Density360150").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density360180").HasColumnName(@"Density360180").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density360250").HasColumnName(@"Density360250").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density44130").HasColumnName(@"Density44130").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density44150").HasColumnName(@"Density44150").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density44180").HasColumnName(@"Density44180").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density134130").HasColumnName(@"Density134130").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density134150").HasColumnName(@"Density134150").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density134180").HasColumnName(@"Density134180").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density136130").HasColumnName(@"Density136130").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density136150").HasColumnName(@"Density136150").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Density136180").HasColumnName(@"Density136180").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"DensityHand130").HasColumnName(@"DensityHand130").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Densityhand150").HasColumnName(@"Densityhand150").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Densityhand180").HasColumnName(@"Densityhand180").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Densitymachine130").HasColumnName(@"Densitymachine130").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().Property<int>(@"Densitymachine").HasColumnName(@"Densitymachine").ValueGeneratedNever();
            modelBuilder.Entity<HeadgearDensity>().HasKey(@"Id");
        }
        private void WavingBlockMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WavingBlock>().Property<int>(@"Magento").HasColumnName(@"Magento").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<int>(@"Shopify").HasColumnName(@"Shopify").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<int>(@"Amazon").HasColumnName(@"Amazon").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<int>(@"Aliexpress").HasColumnName(@"Aliexpress").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<int>(@"Ebay").HasColumnName(@"Ebay").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<string>(@"Size").HasColumnName(@"Size").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<decimal>(@"MagentoTotalRatio").HasColumnName(@"MagentoTotalRatio").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<decimal>(@"ShopifyTotalRatio").HasColumnName(@"ShopifyTotalRatio").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<decimal>(@"AmazonTotalRatio").HasColumnName(@"AmazonTotalRatio").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<decimal>(@"AliexpressTotalRatio").HasColumnName(@"AliexpressTotalRatio").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().Property<decimal>(@"EbayTotalRatio").HasColumnName(@"EbayTotalRatio").ValueGeneratedNever();
            modelBuilder.Entity<WavingBlock>().HasKey(@"Id");

        }
        private void OddMinusSaleMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OddMinusSale>().Property<int>(@"OddQty").HasColumnName(@"OddQty").ValueGeneratedNever();
            modelBuilder.Entity<OddMinusSale>().Property<int>(@"MinusQty").HasColumnName(@"MinusQty").ValueGeneratedNever();
            modelBuilder.Entity<OddMinusSale>().Property<int>(@"Zqty").HasColumnName(@"Zqty").ValueGeneratedNever();
            modelBuilder.Entity<OddMinusSale>().Property<string>(@"OddQtyRate").HasColumnName(@"OddQtyRate").ValueGeneratedNever();
            modelBuilder.Entity<OddMinusSale>().Property<string>(@"MinusQtyRate").HasColumnName(@"MinusQtyRate").ValueGeneratedNever();
            modelBuilder.Entity<OddMinusSale>().HasKey(@"PlateForm");

        }
        private void SingleProductSellMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"Plateform").HasColumnName(@"Plateform").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"UserAccount").HasColumnName(@"UserAccount").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"SaleOrderCode").HasColumnName(@"SaleOrderCode").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"ShippingMethodPlatform").HasColumnName(@"ShippingMethodPlatform").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"ShippingMethod").HasColumnName(@"ShippingMethod").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"WarehouseCode").HasColumnName(@"WarehouseCode").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<DateTime?>(@"DatePaidPlatform").HasColumnName(@"DatePaidPlatform").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<DateTime?>(@"PlatformShipTime").HasColumnName(@"PlatformShipTime").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<DateTime?>(@"DateLatestShip").HasColumnName(@"DateLatestShip").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"Currency").HasColumnName(@"Currency").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"CountryCode").HasColumnName(@"CountryCode").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<int?>(@"ProductCount").HasColumnName(@"ProductCount").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"ProductSku").HasColumnName(@"ProductSku").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<int?>(@"Qty").HasColumnName(@"Qty").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"SubProductSku").HasColumnName(@"SubProductSku").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<int?>(@"SubQty").HasColumnName(@"SubQty").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().Property<string>(@"WarehouseId").HasColumnName(@"WarehouseId").ValueGeneratedNever();
            modelBuilder.Entity<SingleProductSell>().HasKey(@"SubProductSku", @"SaleOrderCode", @"ProductSku");
        }

        private void SingleSalesAnalysisMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SingleSalesAnalysis>().Property<string>(@"SingleSku").HasColumnName(@"SingleSku").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().Property<long>(@"RowNumber").HasColumnName(@"RowNumber").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().Property<int>(@"ThreeDaysSales").HasColumnName(@"ThreeDaysSales").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().Property<int>(@"SevenDaysSales").HasColumnName(@"SevenDaysSales").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().Property<int>(@"ForteenDaysSales").HasColumnName(@"ForteenDaysSales").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().Property<int>(@"ThirtyDaysSales").HasColumnName(@"ThirtyDaysSales").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().Property<string>(@"WarehouseId").HasColumnName(@"WarehouseId").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().Property<string>(@"WarehouseDesc").HasColumnName(@"WarehouseDesc").ValueGeneratedNever();
            modelBuilder.Entity<SingleSalesAnalysis>().HasKey(@"RowNumber");
        }

        private void UsTagTypeInventoryMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsTagTypeInventory>().Property<string>(u => u.ProductSku).HasColumnName(@"ProductSku").ValueGeneratedNever();
            modelBuilder.Entity<UsTagTypeInventory>().Property<int>(u => u.Qty).HasColumnName(@"Qty").ValueGeneratedNever();
            modelBuilder.Entity<UsTagTypeInventory>().Property<string>(u => u.TagType).HasColumnName(@"TagType").ValueGeneratedNever();
            modelBuilder.Entity<UsTagTypeInventory>().Property<long>(u => u.RowNumber).HasColumnName(@"RowNumber").ValueGeneratedNever();
            modelBuilder.Entity<UsTagTypeInventory>().HasKey(@"RowNumber");
        }

        private void ChannelLevelSalesCountMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChannelLevelSalesCount>().Property<string>(u => u.Level).HasColumnName(@"Level").ValueGeneratedNever();
            modelBuilder.Entity<ChannelLevelSalesCount>().Property<int>(u => u.SalesCountQty).HasColumnName(@"SalesCountQty").ValueGeneratedNever();
            modelBuilder.Entity<ChannelLevelSalesCount>().Property<string>(u => u.Channel).HasColumnName(@"Channel").ValueGeneratedNever();
            modelBuilder.Entity<ChannelLevelSalesCount>().Property<long>(u => u.RowNumber).HasColumnName(@"RowNumber").ValueGeneratedNever();
            modelBuilder.Entity<ChannelLevelSalesCount>().HasKey(@"RowNumber");
        }

        private void HairWeftStyleSaleMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HairWeftStyleSale>().Property<string>(u => u.Style).HasColumnName(@"Style").ValueGeneratedNever();
            modelBuilder.Entity<HairWeftStyleSale>().Property<int>(u => u.SaleQty).HasColumnName(@"SaleQty").ValueGeneratedNever();
            modelBuilder.Entity<HairWeftStyleSale>().Property<string>(u => u.SalesRatio).HasColumnName(@"SalesRatio").ValueGeneratedNever();
            modelBuilder.Entity<HairWeftStyleSale>().Property<string>(u => u.LastSalesRatio).HasColumnName(@"LastSalesRatio").ValueGeneratedNever();
            modelBuilder.Entity<HairWeftStyleSale>().HasKey(@"Style");
        }

        private void TotalSaleMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TotalSale>().Property<string>(u => u.ProductCategory).HasColumnName(@"ProductCategory").ValueGeneratedNever();
            modelBuilder.Entity<TotalSale>().Property<int>(u => u.SaleQty).HasColumnName(@"SaleQty").ValueGeneratedNever();
            modelBuilder.Entity<TotalSale>().HasKey(@"ProductCategory");
        }
        public void SaleOrderDetailMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"SaleOrderCode").HasColumnName(@"SaleOrderCode").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"Plateform").HasColumnName(@"Plateform").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<int?>(@"ProcessAgain").HasColumnName(@"ProcessAgain").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"UserAccount").HasColumnName(@"UserAccount").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<int?>(@"PlatformShipStatus").HasColumnName(@"PlatformShipStatus").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<int?>(@"Status").HasColumnName(@"Status").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"Sku").HasColumnName(@"Sku").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<int>(@"Qty").HasColumnName(@"Qty").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"Style").HasColumnName(@"Style").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"Size").HasColumnName(@"Size").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"Density").HasColumnName(@"Density").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"HandArea").HasColumnName(@"HandArea").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().Property<string>(@"ProductType").HasColumnName(@"ProductType").ValueGeneratedNever();
            modelBuilder.Entity<SaleOrderDetail>().HasKey(@"RowNumber");
        }

        public void ListStringModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListStringModel>().Property<string>(p => p.ListItem).HasColumnName(@"ListItem").ValueGeneratedNever();
            modelBuilder.Entity<ListStringModel>().HasKey(@"ListItem");
        }

        private void EcHeadTripLineMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECHeadTripLine>().HasKey(@"RowNumber");
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"Ordercode").HasColumnName(@"Ordercode").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"ReferenceNo").HasColumnName(@"ReferenceNo").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<DateTime>(@"AddTime").HasColumnName(@"AddTime").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<DateTime>(@"ExpectedDate").HasColumnName(@"ExpectedDate").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"OutSku").HasColumnName(@"OutSku").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"ItemSku").HasColumnName(@"ItemSku").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"StoreName").HasColumnName(@"StoreName").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"CompanyName").HasColumnName(@"CompanyName").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"Currery").HasColumnName(@"Currery").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<int?>(@"Qty").HasColumnName(@"Qty").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<decimal?>(@"Price").HasColumnName(@"Price").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<decimal?>(@"Cost").HasColumnName(@"Cost").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"Warehouse").HasColumnName(@"Warehouse").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"ToWarehouse").HasColumnName(@"ToWarehouse").ValueGeneratedNever();
            modelBuilder.Entity<ECHeadTripLine>().Property<string>(@"Remark").HasColumnName(@"Remark").ValueGeneratedNever();
        }
    }
}
