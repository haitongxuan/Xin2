﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Model;
using Xin.Web.Framework.Permission;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChannelLevelSalesCountController : BaseController<ChannelLevelSalesCount>
    {
        private readonly IUowProvider _uowProvider;
        public ChannelLevelSalesCountController(IUowProvider uowProvider) : base(uowProvider)
        {
            _uowProvider = uowProvider;
        }

        [PermissionFilter("ChannelLevelSalesCount.Read")]
        [HttpPost]
        public ActionResult<DataRes<List<ChannelLevelSalesCount>>> Index(DateTime? startDatetime = null, DateTime? endDatetime = null)
        {
            var res = new DataRes<List<ChannelLevelSalesCount>>() { code=ResCode.Success};
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                string dateFilterStr = "";
                if (startDatetime != null && endDatetime != null)
                {
                    dateFilterStr = $"and a.DatePaidPlatform between " +
                    $"'{startDatetime.ToString()}' and '{endDatetime.ToString()}' ";
                }
                else if (startDatetime != null && endDatetime == null)
                {
                    dateFilterStr = $"and a.DatePaidPlatform>='{startDatetime.ToString()}'";
                }
                else if (startDatetime == null && endDatetime != null)
                {
                    dateFilterStr = $"and a.DatePaidPlatform<='{endDatetime.ToString()}'";
                }
                else
                {
                    res.code = ResCode.NoValidate;
                    res.msg = "Please check date filter!";
                }
                string sql = $"select bb.Channel,bb.StoreProductCategory," +
                    $"case when qty is null then 0 else qty end SalesCount from(" +
                    $"select* from (select distinct StoreProductCategory " +
                    $"from EC_Processed_SkuRelationItems) a join(select distinct case " +
                    $"when Plateform in ('ebay','aliexpress','amazon','shopify') then Plateform " +
                    $"when Plateform = 'magento' then '自营站|' + PlatformUserName " +
                    $"else 'Other' end Channel " +
                    $"from EC_SalesOrder) b on 1 = 1 where StoreProductCategory is not null )  bb left join " +
                    $"(select Channel, sum(qty) qty, StoreProductCategory from( " +
                    $"select case when Plateform in ('ebay', 'aliexpress', 'amazon', 'shopify') then Plateform " +
                    $"when Plateform = 'magento' then '自营站|' + PlatformUserName " +
                    $"else 'Other'end Channel, d.StoreProductCategory StoreProductCategory, sum(b.Qty * d.PcrQuantity) qty " +
                    $"from EC_SalesOrder a join EC_SalesOrderDetail b on a.OrderId = b.OrderId " +
                    $"join ec_Processed_SkuRelation c on b.ProductSku = c.ProductSku " +
                    $"join EC_Processed_SkuRelationItems d on c.RelationId = d.RelationId " +
                    $"where d.StoreProductCategory is not null and a.Status = 4  {dateFilterStr}" +
                    $"group by d.StoreProductCategory,a.Plateform,a.PlatformUserName) tt " +
                    $"group by Channel, StoreProductCategory) aa " +
                    $"on aa.StoreProductCategory = bb.StoreProductCategory and aa.Channel = bb.Channel " +
                    $"order by bb.Channel,StoreProductCategory";
                var repository = uow.GetRepository<ChannelLevelSalesCount>();
                var list = repository.ListFromSql(sql).ToList();
                res.data = list;
                return res;
            }
        }
    }
}