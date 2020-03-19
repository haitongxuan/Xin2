using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Service.Context;
using Xin.Entities;

namespace Xin.Service
{
    public class SingleSalesAnlysisRepository :
        EntityRepositoryBase<XinDBContext, SingleSalesAnalysis>,
        ISingleSalesAnlysisRepository
    {
        public SingleSalesAnlysisRepository(XinDBContext context) : base(context)
        {
        }

        public SingleSalesAnlysisRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }

        private string GetQuery(DateTime filterdate, string filterStr)
        {

            const string firstDays = "30";
            const string secondDays = "14";
            const string thirdDays = "7";
            const string forthDays = "3";
            string daysFilterStr = "x.DateWarehouseShipping between CONVERT(DATETIME,'{0}') - {1} and CONVERT(DATETIME,'{0}') ";

            string subQueryStr = "select c.pcrProductSku SubProductSku," +
                "sum(a.Qty*c.PcrQuantity) SubQty,x.WarehouseId " +
                "from EC_SalesOrder x " +
                "join EC_SalesOrderDetail a on x.OrderId=a.OrderId " +
                "join EC_SkuRelation b on a.ProductSku=b.ProductSku and x.WarehouseId=b.WarehouseId " +
                "join EC_SkuRelationItems c on b.RelationId = c.RelationId " +
                "where {0} " +
                "group by c.pcrProductSku,x.WarehouseId ";
            string queryStr = $"select * from " +
                $"(select ROW_NUMBER() over(order by tb0.WarehouseId,tb0.PcrProductSku) RowNumber," +
                $"tb0.PcrProductSku SingleSku,tb0.WarehouseId,wh.WarehouseDesc," +
                $"case when tb1.SubQty is null then 0 else tb1.SubQty end ThirtyDaysSales," +
                $"case when tb2.SubQty is null then 0 else tb2.SubQty end ForteenDaysSales," +
                $"case when tb3.SubQty is null then 0 else tb3.SubQty end SevenDaysSales," +
                $"case when tb4.SubQty is null then 0 else tb4.SubQty end ThreeDaysSales" +
                $" from(select a.WarehouseId, b.PcrProductSku from EC_SkuRelation a " +
                $"join EC_SkuRelationItems b on a.RelationId = b.RelationId group by a.WarehouseId,b.PcrProductSku) tb0 left join" +
                $"({string.Format(subQueryStr, string.Format(daysFilterStr, filterdate.ToString(), firstDays.ToString()))}) as tb1 " +
                $"on tb0.PcrProductSku=tb1.SubProductSku and tb0.WarehouseId=tb1.WarehouseId left join " +
                $"({string.Format(subQueryStr, string.Format(daysFilterStr, filterdate.ToString(), secondDays.ToString()))}) as tb2 " +
                $"on tb1.SubProductSku=tb2.SubProductSku and tb1.WarehouseId=tb2.WarehouseId left join " +
                $"({string.Format(subQueryStr, string.Format(daysFilterStr, filterdate.ToString(), thirdDays.ToString()))}) as tb3 " +
                $"on tb1.SubProductSku=tb3.SubProductSku and tb1.WarehouseId=tb3.WarehouseId left join " +
                $"({string.Format(subQueryStr, string.Format(daysFilterStr, filterdate.ToString(), forthDays.ToString()))}) as tb4 " +
                $"on tb1.SubProductSku=tb4.SubProductSku and tb1.WarehouseId=tb4.WarehouseId left join " +
                $"EC_Warehouse wh on wh.WarehouseId=tb0.WarehouseId ) tt WHERE 1=1 {filterStr} " +
                $"order by rownumber";
            return queryStr;
        }

        public IEnumerable<SingleSalesAnalysis> GetList(DateTime filterdate, string filterStr = null)
        {
            return this.ListFromSql(GetQuery(filterdate, filterStr));
        }

        public DataPage<SingleSalesAnalysis> GetPage(DateTime filterdate, int pageIndex, int pageSize, string filterStr = null)
        {
            DataPage<SingleSalesAnalysis> page = new DataPage<SingleSalesAnalysis>();

            int startrow = (pageIndex - 1) * pageSize + 1;
            int endrow = pageIndex * pageSize;
            string outsideFilterStr = $"{filterStr} and RowNumber between {startrow} and {endrow}";
            page.PageNumber = pageIndex;
            page.PageLength = pageSize;
            page.TotalEntityCount = CountFromSql(GetQuery(filterdate, filterStr));
            page.Data = this.GetList(filterdate, outsideFilterStr);
            return page;
        }
    }
}
