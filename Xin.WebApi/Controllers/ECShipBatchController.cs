using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xin.Common;
using Xin.Entities;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Response.Model;
using Xin.Repository;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Model;
using Xin.Web.Framework.Permission;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ECShipBatchController : BaseController<ECShipBatch>
    {
        public ECShipBatchController(IUowProvider uowProvider) : base(uowProvider)
        {
        }
        //[PermissionFilter("ShipBatch.Read")]
        [Route("getList")]
        [HttpGet]
        public GridPage<List<ECShipBatch>> GetList(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<ECShipBatch>>() { code = ResCode.Success };

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ECShipBatch>();


                    if (pageReq == null)
                    {
                        res.data = repository.GetPage(0, 50).ToList();
                        return res;
                    }
                    else
                    {
                        if (pageReq.pageSize == 0)
                        {
                            pageReq.pageSize = 1;
                        }
                        if (pageReq.pageNum == 0)
                        {
                            pageReq.pageNum = 1;
                        }
                    }
                    int startRow = (pageReq.pageNum - 1) * pageReq.pageSize;
                    Filter<ECShipBatch> filter = new Filter<ECShipBatch>(null);
                    if (pageReq.query.Count > 0)
                    {
                        var fuc = FilterHelper<ECShipBatch>.GetExpression(pageReq.query, "OmsReceivingPage");
                        filter = new Repository.Filter<ECShipBatch>(fuc);
                    }
                    OrderBy<ECShipBatch> orderBy = new OrderBy<ECShipBatch>(null);
                    if (pageReq.order != null)
                    {
                        orderBy = new Repository.OrderBy<ECShipBatch>(pageReq.order.columnName, pageReq.order.reverse);
                    }
                    res.totalCount = repository.Query(filter.Expression, orderBy.Expression).Count();
                    res.data = repository.QueryPage(startRow, pageReq.pageSize, filter.Expression, orderBy.Expression,
                        x =>
                        x.Include(a => a.PackingInfos)
                        .Include(a => a.ProductInfos)).ToList();
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }

        //[PermissionFilter("ShipBatch.add")]
        [Route("addShipBatch")]
        [HttpGet]
        public GridPage<List<ECShipBatch>> addShipBatch(string orderCode)
        {
            var res = new GridPage<List<ECShipBatch>>() { code = ResCode.Success };
            if (string.IsNullOrWhiteSpace(orderCode))
            {
                res.code = ResCode.Error;
                return res;
            }
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ECShipBatch>();
                    string[] code = orderCode.Split(",");
                    List<ECShipBatch> list = new List<ECShipBatch>();
                    foreach (var item in code)
                    {
                        string order = item;
                        WMSGetShipBatchRequest request = new WMSGetShipBatchRequest(ecLogin.UserName, ecLogin.Password, order);
                        var re = request.Request().Result;
                        if (repository.Get(item) == null)
                        {
                            list.Add(Mapper<EC_ShipBatch, ECShipBatch>.Map(re.Body));
                        }
                    }
                    repository.BulkInsert(list, X => X.IncludeGraph = true);
                    uow.SaveChanges();
                    res.data = list;
                }
            }
            catch ( Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;


        }
    }
}