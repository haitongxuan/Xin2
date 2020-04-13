using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xin.Common;
using Xin.Entities;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Web.Framework.Helper;
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
            return DataBaseHelper<BnsSendDeliverdToEc>.GetList(_uowProvider, res, pageReq);
        }

        /// <summary>
        /// paypal放款信息
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetPaypalList")]
        [HttpPost]
        public GridPage<List<BnsPaypalTransactionDetail>> GetPaypalList(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<BnsPaypalTransactionDetail>>() { code = ResCode.Success };
            return DataBaseHelper<BnsPaypalTransactionDetail>.GetList(_uowProvider, res, pageReq, x => x.Include(a => a.BnsPaypalTransactionDetailsCartInfos));
        }

        /// <summary>
        /// 亚马逊放款信息
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetAmazonList")]
        [HttpPost]
        public GridPage<List<BnsAmazonReport>> GetAmazonList(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<BnsAmazonReport>>() { code = ResCode.Success };

            return DataBaseHelper<BnsAmazonReport>.GetList(_uowProvider, res, pageReq);

        }
        /// <summary>
        /// 亚马逊放款信息详情数据
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetAmazonDetailList")]
        [HttpPost]
        public GridPage<List<BnsAmazonReportDetail>> GetAmazonDetailList(DatetimePointPageReq pageReq, int? id)
        {
            if (id != null)
            {
                FilterNode node = new FilterNode();
                node.andorop = "and";
                node.binaryop = "eq";
                node.key = "BnsAmazonReport.Id";
                node.value = id;
                if (pageReq == null)
                {
                    pageReq = new DatetimePointPageReq();
                }
                pageReq.query.Add(node);

            }
            var res = new GridPage<List<BnsAmazonReportDetail>>() { code = ResCode.Success };

            return DataBaseHelper<BnsAmazonReportDetail>.GetList(_uowProvider, res, pageReq);

        }
        /// <summary>
        /// 导入速卖通放款信息
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        [Route("ImportAliLoan")]
        [HttpPost]
        public GridPage<List<ECAliexpressLoaninfo>> ImportAliLoan([FromForm] IFormFile excelFile, string shopName)
        {
            var res = new GridPage<List<ECAliexpressLoaninfo>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    List<ECAliexpressLoaninfo> insertList = new List<ECAliexpressLoaninfo>();
                    var repository = uow.GetRepository<ECAliexpressLoaninfo>();
                    List<ECAliexpressLoaninfo> list = ExcelHelper<ECAliexpressLoaninfo>.ExcelToList(excelFile);
                    foreach (var item in list)
                    {
                        item.StoreName = shopName;
                        var had = repository.Query(a => a.StoreName == item.StoreName && a.FkType == item.FkType
                        && a.FkDATE == item.FkDATE && a.Currency == item.Currency
                        && a.PlateformCode == item.PlateformCode && a.FkAmount == item.FkAmount).FirstOrDefault();
                        if (had != null)
                        {
                            continue;
                        }
                        insertList.Add(item);
                    }
                    repository.BulkInsert(insertList, a => a.IncludeGraph = true);
                    uow.SaveChanges();
                    if (insertList.Count != list.Count)
                    {
                        res.msg = "部分数据重复";
                    }
                    res.data = insertList;
                    res.totalCount = insertList.Count;
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.Error;
                res.data = null;
                res.msg = ex.Message;
            }
            return res;
        }

        /// <summary>
        /// 获取店铺数据
        /// </summary>
        /// <returns></returns>
        [Route("GetShop")]
        [HttpGet]
        public string[] GetShop(string Plateform)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                if (string.IsNullOrWhiteSpace(Plateform))
                {
                    Plateform = "aliexpress";
                }
                var reps = uow.GetRepository<ECSalesOrder>();
                var sql = reps.Query(a => a.Plateform == Plateform).GroupBy(item => new { item.Plateform, item.PlatformUserName }).ToList();
                string[] shops = new string[sql.Count];
                for (int i = 0; i < sql.Count; i++)
                {
                    shops[i] = sql[i].Key.PlatformUserName;
                }
                return shops;
            }
        }

        /// <summary>
        /// 获取平台数据
        /// </summary>
        /// <returns></returns>
        [Route("GetPlateform")]
        [HttpGet]
        public string[] GetPlateform()
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var reps = uow.GetRepository<ECSalesOrder>();
                var sql = reps.GetAll().GroupBy(item => item.Plateform).ToList();
                string[] shops = new string[sql.Count];
                for (int i = 0; i < sql.Count; i++)
                {
                    shops[i] = sql[i].Key;
                }
                return shops;
            }
        }


        /// <summary>
        /// 获取速卖通导入数据
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetAliLoanList")]
        [HttpPost]
        public GridPage<List<ECAliexpressLoaninfo>> GetAliLoanList(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<ECAliexpressLoaninfo>>() { code = ResCode.Success };
            return DataBaseHelper<ECAliexpressLoaninfo>.GetList(_uowProvider, res, pageReq);
        }

        /// <summary>
        /// 导入东恒成本价
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        [Route("ImportDHCoust")]
        [HttpPost]
        public GridPage<List<ECDHCost>> ImportDHCoust([FromForm] IFormFile excelFile)
        {
            var res = new GridPage<List<ECDHCost>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {

                    List<ECDHCost> list = ExcelHelper<ECDHCost>.ExcelToList(excelFile);
                    List<ECDHCost> insertList = new List<ECDHCost>();
                    var repository = uow.GetRepository<ECDHCost>();
                    foreach (var item in list)
                    {
                        if (repository.Query(a => a.Month == item.Month && a.ProductSKU == item.ProductSKU
                        && a.Price == item.Price).FirstOrDefault() == null)
                        {
                            item.Enterdate = DateTime.Now;
                            insertList.Add(item);
                        }
                    }
                    repository.BulkInsert(insertList);
                    uow.SaveChanges();
                    if (insertList.Count != list.Count)
                    {
                        res.msg = "部分数据重复";
                    }
                    res.data = insertList;
                    res.totalCount = insertList.Count;
                }
            }
            catch (Exception ex)
            {

                res.code = ResCode.Error;
                res.data = null;
                res.msg = ex.Message;
            }

            return res;

        }

        /// <summary>
        /// 获取东恒成本价导入数据
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetDHCostList")]
        [HttpPost]
        public GridPage<List<ECDHCost>> GetDHCostList(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<ECDHCost>>() { code = ResCode.Success };
            return DataBaseHelper<ECDHCost>.GetList(_uowProvider, res, pageReq);
        }

        /// <summary>
        /// 获取复购客户导入数据
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetRepeatCustList")]
        [HttpPost]
        public GridPage<List<ECRepeatCust>> GetRepeatCustList(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<ECRepeatCust>>() { code = ResCode.Success };
            return DataBaseHelper<ECRepeatCust>.GetList(_uowProvider, res, pageReq);
        }

        /// <summary>
        /// 导入复购客户
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        [Route("ImportRepeatCust")]
        [HttpPost]
        public GridPage<List<ECRepeatCust>> ImportRepeatCust([FromForm] IFormFile excelFile, string plateForm, string shopName)
        {
            var res = new GridPage<List<ECRepeatCust>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {

                    List<ECRepeatCust> list = ExcelHelper<ECRepeatCust>.ExcelToList(excelFile);
                    List<ECRepeatCust> insertList = new List<ECRepeatCust>();
                    var repository = uow.GetRepository<ECRepeatCust>();
                    foreach (var item in list)
                    {
                        item.PlateForm = plateForm;
                        item.StoreName = shopName;
                        if (repository.Query(a => a.PlateForm == item.PlateForm && a.StoreName == item.StoreName
                        && a.Email == item.Email && a.FkDate == item.FkDate && a.FkType == item.FkType
                        && a.DealMonth == item.DealMonth).FirstOrDefault() == null)
                        {
                            insertList.Add(item);
                        }
                    }
                    repository.BulkInsert(insertList);
                    uow.SaveChanges();
                    if (insertList.Count != list.Count)
                    {
                        res.msg = "部分数据重复";
                    }
                    res.data = insertList;
                    res.totalCount = insertList.Count;
                }
            }
            catch (Exception ex)
            {

                res.code = ResCode.Error;
                res.data = null;
                res.msg = ex.Message;
            }

            return res;

        }
        /// <summary>
        /// 财务报表
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetFinancialStatement")]
        [HttpPost]
        public GridPage<List<CwAccountQueryReport>> GetFinancialStatement(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<CwAccountQueryReport>> { code = ResCode.Success };
            res = DataBaseHelper<CwAccountQueryReport>.GetFromProcedure(_uowProvider, res, pageReq, "EXECUTE CwAccountQuery_sp");
            return res;


        }

        [Route("GetDeliver")]
        [HttpPost]
        public MangatoDeliverReturn GetDeliver(MagentoReqModel data) {
            MangatoDeliverReturn res = new MangatoDeliverReturn();
            res.Status = "success";
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repo = uow.GetRepository<BnsSendDeliverdToEc>();
                    BnsSendDeliverdToEc model = repo.Query(a => a.ShippingMethodNo == data.express_num).FirstOrDefault();
                    Dictionary<string, Object> dic = new Dictionary<string, Object>();
                    dic.Add("trackinfo", model.Trackinfo);
                    //dic.Add("carrier_code", model.carr);
                    dic.Add("express_num", model.Trackinfo);
                    dic.Add("delivered_status", model.DeliveredStatus);
                    res.data = dic;
                }
            }
            catch (Exception ex)
            {
                res.Status = "fail";
                res.message = ex.Message;
            }
           
            return res;
        }
    }
}