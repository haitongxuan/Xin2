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
        }



        public virtual DbSet<SingleProductSell> SingleProductSells { get; set; }
        public virtual DbSet<SingleSalesAnalysis> SingleSalesAnalyses { get; set; }
        public virtual DbSet<UsTagTypeInventory> UsTagTypeInventories { get; set; }
        public virtual DbSet<ChannelLevelSalesCount> ChannelLevelSalesCounts { get; set; }
        public virtual DbSet<HairWeftStyleSale> HairWeftStyleSales { get; set; }
        public virtual DbSet<OddMinusSale> OddMinusSale { get; set; }
        public virtual DbSet<TotalSale> TotalSales { get; set; }
        public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
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
        public void SaleOrderDetailMapping(ModelBuilder modelBuilder) { 
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
    }
}
