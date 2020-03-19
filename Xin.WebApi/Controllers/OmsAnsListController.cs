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
using Xin.ExternalService.EC.WMS.Request;
using Xin.ExternalService.EC.WMS.Request.Model;
using Xin.ExternalService.EC.WMS.Response.Model;
using Xin.Repository;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Model;
using Xin.Web.Framework.Permission;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OmsAnsListController : BaseController<BnsOmsReceivingCodeRecord>
    {
        public OmsAnsListController(IUowProvider uowProvider) : base(uowProvider)
        {
        }
        //[PermissionFilter("OmsAns.Read")]
        [Route("GetList")]
        [HttpPost]
        public GridPage<List<BnsOmsReceivingCodeRecord>> GetList(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<BnsOmsReceivingCodeRecord>>() { code = ResCode.Success };

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<BnsOmsReceivingCodeRecord>();

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
                    Filter<BnsOmsReceivingCodeRecord> filter = new Filter<BnsOmsReceivingCodeRecord>(null);
                    if (pageReq.query.Count > 0)
                    {
                        var fuc = FilterHelper<BnsOmsReceivingCodeRecord>.GetExpression(pageReq.query, "OmsReceivingPage");
                        filter = new Repository.Filter<BnsOmsReceivingCodeRecord>(fuc);
                    }
                    OrderBy<BnsOmsReceivingCodeRecord> orderBy = new OrderBy<BnsOmsReceivingCodeRecord>(null);
                    if (pageReq.order != null)
                    {
                        orderBy = new Repository.OrderBy<BnsOmsReceivingCodeRecord>(pageReq.order.columnName, pageReq.order.reverse);
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
        /// 添加入库单
        /// </summary>
        /// <param name="pageReq"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        //[PermissionFilter("OmsAns.Read")]
        [Route("AddRecivingCode")]
        [HttpPost]
        public GridPage<List<BnsOmsReceivingCodeRecord>> AddRecivingCode(string[] codes)
        {
            var res = new GridPage<List<BnsOmsReceivingCodeRecord>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<BnsOmsReceivingCodeRecord>();
                    var asnRepository = uow.GetRepository<ECAsn>();
                    List<BnsOmsReceivingCodeRecord> list = new List<BnsOmsReceivingCodeRecord>();
                    List<ECAsn> detailList = new List<ECAsn>();
                    DateTime createDate = DateTime.Now;
                    var reqModel = new GetAsnListRequestModel();

                    foreach (var item in codes)
                    {
                        if (string.IsNullOrWhiteSpace(item))
                        {
                            res.code = ResCode.Error;
                            continue;
                        }
                        if (repository.Query(x => x.OmsReceivingCode == item).FirstOrDefault() != null)
                        {
                            res.msg += "入库单号: " + item + "已经有记录,请不要重复拉取";
                            continue;
                        }
                        BnsOmsReceivingCodeRecord temp = new BnsOmsReceivingCodeRecord();
                        temp.CreateDate = createDate;
                        temp.Message = "创建拉取任务";
                        temp.StopFlag = false;
                        temp.OmsReceivingCode = item;
                        temp.State = 1;
                        list.Add(temp);

                    }
                    reqModel.receivingCodeArr = codes;
                    reqModel.page = 1;
                    reqModel.pageSize = 50;
                    GetAsnListRequest req = new GetAsnListRequest(omsApi.ApiToken, omsApi.ApiKey, reqModel);
                    var response = req.Request().Result;
                    foreach (var item in response.data)
                    {
                        detailList.Add(Mapper<GetAsnListResponseModel, ECAsn>.Map(item));
                    }
                    asnRepository.BulkInsert(detailList, x => x.IncludeGraph = true);
                    repository.BulkInsert(list, x => x.IncludeGraph = true);
                    uow.SaveChanges();
                    res.data = list;
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }
        //[PermissionFilter("OmsAns.Read")]
        [Route("GetDetails")]
        [HttpPost]
        public ActionResult<DataRes<ECAsn>> GetAnsDetail(int id)
        {
            var res = new DataRes<ECAsn>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<BnsOmsReceivingCodeRecord>();
                    var ansRepository = uow.GetRepository<ECAsn>();
                    BnsOmsReceivingCodeRecord model = repository.Get(id);
                    var ansModel = ansRepository.Query(x => x.ReceiveCode == model.OmsReceivingCode, null,
                        x => x.Include(a => a.Items)
                        .Include(a => a.ReceivingCost))
                        .FirstOrDefault();
                    res.data = ansModel;
                    if (ansModel == null)
                    {
                        res.code = ResCode.NotFound;
                        res.msg = "此Id数据还未拉取";
                    }
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