using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Entities;
using Xin.Repository;
using Xin.Service;
using Xin.Entities.VirtualEntity;
using Microsoft.AspNetCore.Authorization;
using Xin.Web.Framework.Permission;
using Xin.Web.Framework.Model;

namespace Xin.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class ECSingleProductSellViewController : ControllerBase
    {
        private readonly IUowProvider _uowProvider;
        public ECSingleProductSellViewController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        [PermissionFilter("ECSingleProductSell.Read")]
        [Route("GetList")]
        [HttpPost]
        public ActionResult<DataRes<List<SingleProductSell>>> GetList(OrderReq req)
        {
            var res = new DataRes<List<SingleProductSell>>() { code = ResCode.Success };
            if (req != null)
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    string sql = "select x.Plateform,x.UserAccount,x.SaleOrderCode," +
                    "x.ShippingMethodPlatform, x.ShippingMethod, x.WarehouseCode," +
                    "x.DatePaidPlatform, x.PlatformShipTime, x.DateLatestShip, x.Currency," +
                    "x.CountryCode, ProductCount,a.ProductSku, a.Qty,c.pcrProductSku SubProductSku," +
                    " a.Qty * c.PcrQuantity SubQty, b.WarehouseId " +
                    "from EC_SalesOrder x join EC_SalesOrderDetail a on x.OrderId = a.OrderId " +
                    "join EC_SkuRelation b on a.ProductSku = b.ProductSku " +
                    "join EC_SkuRelationItems c on b.relationid = c.relationid " +
                    "order by x.SaleOrderCode";
                    var repository = uow.GetRepository<SingleProductSell>();
                    string orderStr = req.order + (req.order.reverse ? " desc" : "");
                    res.data = repository.ListFromSql(sql, FilterNode.ListToString(req.query), orderStr).ToList();
                }
            else
            {
                res.code = ResCode.NoValidate;
                res.msg = ResMsg.ParameterIsNull;
            }
            return res;
        }


    }
}