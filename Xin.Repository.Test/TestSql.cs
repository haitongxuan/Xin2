using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.Repository;
using Xin.Entities;
using System.Collections.Generic;
using Xin.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Xin.Entities.VirtualEntity;
using Xin.Common;

namespace Xin.Repository.Test
{
    [TestClass]
    public class TestSql
    {
        [TestMethod]
        public void TestFromSql()
        {
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<SingleProductSell>)))
                .Returns(new GenericEntityRepository<SingleProductSell>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);

            var uow = provider.CreateUnitOfWork();
            var repository = uow.GetRepository<SingleProductSell>();
            var list = repository.FromSql("select x.Plateform,x.UserAccount,x.SaleOrderCode," +
                "x.ShippingMethodPlatform, x.ShippingMethod, x.WarehouseCode," +
                "x.DatePaidPlatform, x.PlatformShipTime, x.DateLatestShip, x.Currency," +
                "x.CountryCode, ProductCount,a.ProductSku, a.Qty,c.pcrProductSku SubProductSku," +
                " a.Qty * c.PcrQuantity SubQty, b.WarehouseId " +
                "from EC_SalesOrder x join EC_SalesOrderDetail a on x.OrderId = a.OrderId " +
                "join EC_SkuRelation b on a.ProductSku = b.ProductSku " +
                "join EC_SkuRelationItems c on b.relationid = c.relationid " +
                "order by x.SaleOrderCode").ToList();
            string subsku = list[0].SubProductSku;
        }

    }
}