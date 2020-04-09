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

            return DataBaseHelper<BnsAmazonReport>.GetList(_uowProvider, res, pageReq, x => x.Include(a => a.BnsAmazonReportDetails));

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
                        var had = repository.Query(a => a.StoreName == item.StoreName && a.LoanDate == item.LoanDate
                        && a.LoanType == item.LoanType && a.TransactionInfo == item.TransactionInfo
                        && a.PlateForm == item.PlateForm && a.FundsDetail == item.FundsDetail).FirstOrDefault();
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
        /// 获取速卖通店铺数据
        /// </summary>
        /// <returns></returns>
        [Route("GetShop")]
        [HttpGet]
        public string[] GetShop()
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var reps = uow.GetRepository<ECSalesOrder>();
                var sql = reps.Query(a => a.Plateform == "aliexpress").GroupBy(item => new { item.Plateform, item.PlatformUserName }).ToList();
                string[] shops = new string[sql.Count];
                for (int i = 0; i < sql.Count; i++)
                {
                    shops[i] = sql[i].Key.PlatformUserName;
                }
                return shops;
            }
        }
        /// <summary>
        /// 获取速卖通店铺数据
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
        /// 导入东恒成本价
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

    }
}