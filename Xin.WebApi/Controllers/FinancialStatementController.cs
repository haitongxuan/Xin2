using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xin.Common;
using Xin.Entities;
using Xin.Repository;
using Xin.Web.Framework.Model;

namespace Xin.WebApi.Controllers
{
    /// <summary>
    /// 财务报表
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialStatementController : ControllerBase
    {
        private IUowProvider _uowProvider;

        public FinancialStatementController(IUowProvider uowProvider)
        {
            var config = new AppConfigurationServices().Configuration;
            _uowProvider = uowProvider;
        }
        /// <summary>
        /// 物流详情
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetOrderDeliverList")]
        [HttpPost]
        public GridPage<List<BnsSendDeliverdToEc>> GetDeliverList(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<BnsSendDeliverdToEc>>() { code = ResCode.Success };

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<BnsSendDeliverdToEc>();

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
                    Filter<BnsSendDeliverdToEc> filter = new Filter<BnsSendDeliverdToEc>(null);
                    if (pageReq.query.Count > 0)
                    {
                        var fuc = FilterHelper<BnsSendDeliverdToEc>.GetExpression(pageReq.query, "OrderDeliver");
                        filter = new Repository.Filter<BnsSendDeliverdToEc>(fuc);
                    }
                    OrderBy<BnsSendDeliverdToEc> orderBy = new OrderBy<BnsSendDeliverdToEc>(null);
                    if (pageReq.order != null)
                    {
                        orderBy = new Repository.OrderBy<BnsSendDeliverdToEc>(pageReq.order.columnName, pageReq.order.reverse);
                    }
                    res.totalCount = repository.Query(filter.Expression, orderBy.Expression).Count();
                    res.data = repository.QueryPage(startRow, pageReq.pageSize, filter.Expression, orderBy.Expression).ToList();
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }
        /// <summary>
        /// paypal交易信息
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetPaypalList")]
        [HttpPost]
        public GridPage<List<BnsPaypalTransactionDetail>> GetPaypalList(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<BnsPaypalTransactionDetail>>() { code = ResCode.Success };

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<BnsPaypalTransactionDetail>();

                    if (pageReq == null)
                    {
                        res.data = repository.GetPage(0, 50).ToList();
                        return res;
                    }
                    else
                    {
                        if (pageReq.pageSize == 0)
                        {
                            pageReq.pageSize = 50;
                        }
                        if (pageReq.pageNum == 0)
                        {
                            pageReq.pageNum = 1;
                        }
                    }
                    int startRow = (pageReq.pageNum - 1) * pageReq.pageSize;
                    Filter<BnsPaypalTransactionDetail> filter = new Filter<BnsPaypalTransactionDetail>(null);
                    if (pageReq.query.Count > 0)
                    {
                        var fuc = FilterHelper<BnsPaypalTransactionDetail>.GetExpression(pageReq.query, "BnsPaypalTransactionDetail");
                        filter = new Repository.Filter<BnsPaypalTransactionDetail>(fuc);
                    }
                    OrderBy<BnsPaypalTransactionDetail> orderBy = new OrderBy<BnsPaypalTransactionDetail>(null);
                    if (pageReq.order != null)
                    {
                        orderBy = new Repository.OrderBy<BnsPaypalTransactionDetail>(pageReq.order.columnName, pageReq.order.reverse);
                    }
                    res.totalCount = repository.Query(filter.Expression, orderBy.Expression).Count();
                    res.data = repository.QueryPage(startRow, pageReq.pageSize, filter.Expression, orderBy.Expression, x => x.Include(a => a.BnsPaypalTransactionDetailsCartInfos)).ToList();
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }
        /// <summary>
        /// 亚马逊交易信息
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetAmazonList")]
        [HttpPost]
        public GridPage<List<BnsAmazonReport>> GetAmazonList(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<BnsAmazonReport>>() { code = ResCode.Success };

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<BnsAmazonReport>();

                    if (pageReq == null)
                    {
                        res.data = repository.GetPage(0, 50).ToList();
                        return res;
                    }
                    else
                    {
                        if (pageReq.pageSize == 0)
                        {
                            pageReq.pageSize = 50;
                        }
                        if (pageReq.pageNum == 0)
                        {
                            pageReq.pageNum = 1;
                        }
                    }
                    int startRow = (pageReq.pageNum - 1) * pageReq.pageSize;
                    Filter<BnsAmazonReport> filter = new Filter<BnsAmazonReport>(null);
                    if (pageReq.query.Count > 0)
                    {
                        var fuc = FilterHelper<BnsAmazonReport>.GetExpression(pageReq.query, "BnsAmazonReport");
                        filter = new Repository.Filter<BnsAmazonReport>(fuc);
                    }
                    OrderBy<BnsAmazonReport> orderBy = new OrderBy<BnsAmazonReport>(null);
                    if (pageReq.order != null)
                    {
                        orderBy = new Repository.OrderBy<BnsAmazonReport>(pageReq.order.columnName, pageReq.order.reverse);
                    }
                    res.totalCount = repository.Query(filter.Expression, orderBy.Expression).Count();
                    res.data = repository.QueryPage(startRow, pageReq.pageSize, filter.Expression, orderBy.Expression, x => x.Include(a => a.BnsAmazonReportDetails)).ToList();
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }
    }
}