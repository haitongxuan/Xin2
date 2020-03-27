using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Service.Context;

namespace Xin.Service.Repository
{
    public class SaleOrderDetailRepository : EntityRepositoryBase<XinDBContext, SaleOrderDetail>, ISaleOrderDetailRepository
    {
        public SaleOrderDetailRepository(XinDBContext context) : base(context)
        {
        }

        public SaleOrderDetailRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }
        public IEnumerable<SaleOrderDetail> GetList(string startTime  ,string endTime)
        {
           
            string sql = "if exists(select * from tempdb..sysobjects where id=object_id('tempdb..##TempOrder'))DROP TABLE ##TempOrder;" +
                        "if exists(select * from tempdb..sysobjects where id=object_id('tempdb..##TempSku'))DROP TABLE ##TempSku;" +
                        "if exists(select * from tempdb..sysobjects where id=object_id('tempdb..##TempOrderDetail'))DROP TABLE ##TempOrderDetail;" +
                        "if exists(select * from tempdb..sysobjects where id=object_id('tempdb..##tempProductInfo'))DROP TABLE ##tempProductInfo;" +
                        "SELECT pcrproductsku,style,ISNULL(SIZE, '') size,Density,HandArea,productcategory into ##tempProductInfo FROM (SELECT pcrproductsku,style,SIZE,Density,HandArea,productcategory,ROW_NUMBER () OVER ( PARTITION BY pcrproductsku ORDER BY relationid ) AS rowNum FROM EC_Processed_SkuRelationItems ) a WHERE rowNum = 1;" +
                        $"SELECT a.WarehouseId,a.plateform,a.UserAccount,a.WarehouseCode,a.ProcessAgain,a.DateWarehouseShipping,a.PlatformShipTime,a.PlatformShipStatus,a.Status,a.SaleOrderCode,b.ProductSku,b.Sku,b.Qty into ##TempOrder from (SELECT OrderId,plateform,UserAccount, WarehouseId,WarehouseCode,ProcessAgain,DateWarehouseShipping,PlatformShipTime,PlatformShipStatus,Status,SaleOrderCode from [dbo].[EC_SalesOrder] WHERE createddate >= '{startTime}' and createddate<'{endTime}'  and  OrderType = 'sale' and Status in (2,3,4,5,6,7)) a left JOIN EC_SalesOrderDetail b on a.OrderId = b.OrderId;" +
                        "SELECT a.productsku ,b.PcrProductSku,b.PcrQuantity, type = CASE WHEN ProductCategory LIKE '%发帘' THEN '发帘' WHEN ProductCategory LIKE '%发块' THEN '发块' ELSE '' END into ##TempSku FROM EC_Processed_SkuRelation a left JOIN   EC_Processed_SkuRelationItems b ON a.relationid = b.relationid;" +
                        "SELECT SaleOrderCode, plateform ,useraccount,processagain,platformshipstatus,status,b.productsku,ISNULL(qty, 1)*ISNULL(PcrQuantity, 1) qty,ISNULL(PcrProductSku, a.productsku) sku,type into ##TempOrderDetail from ##TempOrder a LEFT JOIN ##TempSku b ON a.ProductSku = b.productsku;" +
                        "select row_number() over(order by SaleOrderCode) as RowNumber ,* from  ##TempOrderDetail a  LEFT JOIN ##tempProductInfo b on a.sku = b.pcrproductsku";
            return this.FromSql(sql);



        }
    }
}
