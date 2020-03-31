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
        public virtual DbSet<PlateformLevel> PlateformLevels { get; set; }

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
            modelBuilder.Entity<ListStringModel>().Property<string>(p=>p.ListItem).HasColumnName(@"ListItem").ValueGeneratedNever();
            modelBuilder.Entity<ListStringModel>().HasKey(@"ListItem");
        }
    }
}
