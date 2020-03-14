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
        }

        public virtual DbSet<SingleProductSell> SingleProductSells
        {
            get;
            set;
        }

        public virtual DbSet<SingleSalesAnalysis> SingleSalesAnalyses { get; set; }

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
    }
}
