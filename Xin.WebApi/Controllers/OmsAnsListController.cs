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
        public ActionResult<DataRes<List<BnsOmsReceivingCodeRecord>>> GetList(DatetimePointPageReq pageReq)
        {

            var res = new DataRes<List<BnsOmsReceivingCodeRecord>>() { code = ResCode.Success };

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<BnsOmsReceivingCodeRecord>();

                if (pageReq == null)
                {
                    res.data = repository.GetPage(0, 50).ToList();
                    return res;
                }
                int startRow = (pageReq.pageNum - 1) * pageReq.pageSize;

                #region 暂无排序,需要表达式树
                if (pageReq.order != null)
                {
                    if (pageReq.order.reverse)
                    {
                        res.data = repository.GetPage(startRow, pageReq.pageSize).ToList();
                    }
                    else
                    {
                        res.data = repository.GetPage(startRow, pageReq.pageSize).ToList();
                    }
                }
                else
                {
                    res.data = repository.GetPage(startRow, pageReq.pageSize).ToList();
                }
                #endregion
            }
            return res;

        }
        //[PermissionFilter("OmsAns.Read")]
        [Route("AddRecivingCode")]
        [HttpPost]
        public ActionResult<DataRes<List<BnsOmsReceivingCodeRecord>>> AddRecivingCode(DatetimePointPageReq pageReq, string codes)
        {
            var res = new DataRes<List<BnsOmsReceivingCodeRecord>>() { code = ResCode.Success };
            if (string.IsNullOrWhiteSpace(codes))
            {
                res.code = ResCode.Error;
                return res;
            }
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<BnsOmsReceivingCodeRecord>();
                var asnRepository = uow.GetRepository<ECAsn>();

                string[] code = codes.Split(",");
                List<BnsOmsReceivingCodeRecord> list = new List<BnsOmsReceivingCodeRecord>();
                List<ECAsn> detailList = new List<ECAsn>();
                DateTime createDate = DateTime.Now;
                var reqModel = new GetAsnListRequestModel();

                foreach (var item in code)
                {
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
                reqModel.receivingCodeArr = code;
                reqModel.page = 1;
                reqModel.pageSize = 50;
                GetAsnListRequest req = new GetAsnListRequest("7417441d04ea6267a57cbb6cdced5552", "726fb5fbe5b258d33e32aba78df42e83", reqModel);
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
            return res;
        }
        //[PermissionFilter("OmsAns.Read")]
        [Route("GetDetails")]
        [HttpPost]
        public ActionResult<DataRes<ECAsn>> GetAnsDetail(int id)
        {
            var res = new DataRes<ECAsn>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<BnsOmsReceivingCodeRecord>();
                var ansRepository = uow.GetRepository<ECAsn>();
                BnsOmsReceivingCodeRecord model = repository.Get(id);
                var ansModel = ansRepository.Query(x => x.ReceiveCode == model.OmsReceivingCode, null,
                    x => x.Include(a => a.Items)
                    .Include(a=>a.ReceivingCost))
                    .FirstOrDefault();
                res.data = ansModel;
                if (ansModel==null)
                {
                    res.code = ResCode.NotFound;
                    res.msg = "此Id数据还未拉取";
                }
            }
            return res;
        }
    }
}