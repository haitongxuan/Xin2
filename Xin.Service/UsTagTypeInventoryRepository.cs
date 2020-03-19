using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Service.Context;
using Xin.Entities;
using Microsoft.Extensions.Logging;

namespace Xin.Service
{
    public class UsTagTypeInventoryRepository :
        EntityRepositoryBase<XinDBContext, UsTagTypeInventory>,
        IUsTagTypeInventoryRepository
    {
        public UsTagTypeInventoryRepository(XinDBContext context) : base(context)
        {
        }

        public UsTagTypeInventoryRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }

        public IEnumerable<UsTagTypeInventory> GetList(string filterStr = null)
        {
            string queryStr = $"select * from (" +
                $"select ProductSku,(a.Qty+c.ReceiveQty-b.SalesQty) Qty,a.TagType from Bns_UsBaseInventory a " +
                $"left join (select ProductSku SalesProductSku,TagType,sum(Qty) SalesQty from( " +
                $"select case when UserAccount in ('Amazon_Unice','ebay_unice_jolia','ebay_unice_sunber', " +
                $"'ebay_unicehair','ebay_unicewigs','Unice','unicemall') then 'unice' else 'normal' end TagType, " +
                $"b.ProductSku,sum(b.Qty) Qty from EC_SalesOrder a join EC_SalesOrderDetail b on a.OrderId = b.OrderId " +
                $"where WarehouseId = 21 group by ProductSku,UserAccount) aa group by ProductSku, TagType) b " +
                $"on a.ProductSku = b.SalesProductSku and a.TagType = b.TagType left join(select " +
                $"case when lower(Remark)= 'unice' then 'unice' else 'normal' end TagType, b.ProductBarcode ReceiveProductSku, " +
                $"SUM(convert(int, b.OpQuantity)) ReceiveQty from EC_ShipBatch a join EC_ShipBatchProductInfo b " +
                $"on a.OrderCode = b.OrderCode group by Remark,ProductBarcode) c on " +
                $"a.ProductSku = c.ReceiveProductSku and a.TagType = c.TagType) tba where 1=1 {filterStr}";

            return this.ListFromSql(queryStr);
        }

        public IEnumerable<UsTagTypeInventory> GetPage(int pageIndex, int pageSize, string filterStr = null)
        {
            int startrow = (pageIndex - 1) * pageSize + 1;
            int endrow = pageIndex * pageSize;
            string outsideFilterStr = $"{filterStr} and RowNumber between {startrow} and {endrow}";
            return this.GetList(outsideFilterStr);
        }
    }
}
