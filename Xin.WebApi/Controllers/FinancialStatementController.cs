using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _hostingEnvironment;

        private IUowProvider _uowProvider;

        public FinancialStatementController(IHostingEnvironment hostingEnvironment, IUowProvider uowProvider)
        {
            _hostingEnvironment = hostingEnvironment;
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
            res = DataBaseHelper<BnsAmazonReportDetail>.GetList(_uowProvider, res, pageReq);
            return res;
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
                        item.Enterdate = DateTime.Now;
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
            StringBuilder sbCommon = new StringBuilder();
            StringBuilder sbLoandate = new StringBuilder();
            List<FilterNode> list = new List<FilterNode>();
            foreach (var item in pageReq.query)
            {
                if (item.value != null)
                {
                    switch (item.key.ToLower())
                    {
                        case "loandate":
                            list.Add(item);
                            break;
                        case "status":
                            sbCommon.Append($" and '{item.value}' = CASE WHEN t1.Status = 0 THEN '已废弃' WHEN t1.Status = 1 THEN '付款未完成' " +
                                $"WHEN t1.Status = 2 THEN '待发货审核' WHEN t1.Status = 3 THEN '待发货' WHEN t1.Status = 4 THEN '已发货' " +
                                $"WHEN t1.Status = 5 THEN '冻结中' WHEN t1.Status = 6 THEN '缺货' WHEN t1.Status = 7 THEN '问题件' " +
                                $"WHEN t1.Status = 8 THEN '未付款' END ");
                            break;
                        case "ordertype":
                            sbCommon.Append($" and '{item.value}'= CASE WHEN orderType = 'sale' THEN '正常销售订单' WHEN orderType = 'resend' " +
                                $"THEN '重发订单' WHEN orderType = 'line' AND LEFT(t1.refno, 1) NOT IN('Y', 'H', 'S', 'A') " +
                                $"THEN '线下订单' WHEN orderType = 'line' AND LEFT(t1.refno, 1) IN('Y', 'H', 'S', 'A') " +
                                $"THEN '营销订单' END ");
                            break;
                        case "storename":
                            sbCommon.Append($" and platformUserName {Operate.GetSqlOperate(item.binaryop)} '{item.value}' ");
                            break;
                        default:
                            sbCommon.Append($" and {item.key} {Operate.GetSqlOperate(item.binaryop)} '{item.value}' ");
                            break;
                    }
                }
            }
            var whereSql = new SqlParameter("@whereSql", sbCommon.ToString());

            pageReq.query = list;
            res = DataBaseHelper<CwAccountQueryReport>.GetFromProcedure(_uowProvider, res, pageReq, false, "EXECUTE CwAccountQuery_sp @whereSql", whereSql);
            res.data = res.data.OrderBy(a => a.RefNo).ThenByDescending(a => a.Amountpaid).ToList();
            return res;
        }

        /// <summary>
        /// 财务报表导出
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("ExportFinancialStatement")]
        [HttpPost]
        public void ExportFinancialStatement(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<CwAccountQueryReport>> { code = ResCode.Success };
            StringBuilder sbCommon = new StringBuilder();
            StringBuilder sbLoandate = new StringBuilder();
            List<FilterNode> list = new List<FilterNode>();
            foreach (var item in pageReq.query)
            {
                if (item.value != null)
                {
                    switch (item.key.ToLower())
                    {
                        case "loandate":
                            list.Add(item);
                            break;
                        case "status":
                            sbCommon.Append($" and '{item.value}' = CASE WHEN t1.Status = 0 THEN '已废弃' WHEN t1.Status = 1 THEN '付款未完成' " +
                                $"WHEN t1.Status = 2 THEN '待发货审核' WHEN t1.Status = 3 THEN '待发货' WHEN t1.Status = 4 THEN '已发货' " +
                                $"WHEN t1.Status = 5 THEN '冻结中' WHEN t1.Status = 6 THEN '缺货' WHEN t1.Status = 7 THEN '问题件' " +
                                $"WHEN t1.Status = 8 THEN '未付款' END ");
                            break;
                        case "ordertype":
                            sbCommon.Append($" and '{item.value}'= CASE WHEN orderType = 'sale' THEN '正常销售订单' WHEN orderType = 'resend' " +
                                $"THEN '重发订单' WHEN orderType = 'line' AND LEFT(t1.refno, 1) NOT IN('Y', 'H', 'S', 'A') " +
                                $"THEN '线下订单' WHEN orderType = 'line' AND LEFT(t1.refno, 1) IN('Y', 'H', 'S', 'A') " +
                                $"THEN '营销订单' END ");
                            break;
                        case "storename":
                            sbCommon.Append($" and platformUserName {Operate.GetSqlOperate(item.binaryop)} '{item.value}' ");
                            break;
                        default:
                            sbCommon.Append($" and {item.key} {Operate.GetSqlOperate(item.binaryop)} '{item.value}' ");
                            break;
                    }
                }
            }
            var whereSql = new SqlParameter("@whereSql", sbCommon.ToString());
            pageReq.query = list;
            res = DataBaseHelper<CwAccountQueryReport>.GetFromProcedure(_uowProvider, res, pageReq, true, "EXECUTE CwAccountQuery_sp @whereSql", whereSql);
            //将已经解码的字符再次进行编码.
            Response.Headers.Add("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("FinancialStatementReport.xlsx"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8";
            Response.Body.Write(ExcelHelper<CwAccountQueryReport>.NpoiListToExcel(res.data.OrderBy(a => a.RefNo).ThenByDescending(a => a.Amountpaid).ToList()));
            Response.Body.Flush();
            Response.Body.Close();
        }


        /// <summary>
        /// 商城API获取物流详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("GetDeliver")]
        [HttpPost]
        public MangatoDeliverReturn GetDeliver(MagentoReqModel data)
        {
            MangatoDeliverReturn res = new MangatoDeliverReturn();
            res.Status = "success";
            if (string.IsNullOrWhiteSpace(data.express_num))
            {
                res.Status = "false";
                res.message = "express_num不能为空";
                return res;
            }
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var saleOrderRepository = uow.GetRepository<ECSalesOrder>();
                    var carryRepository = uow.GetRepository<BnsShippingEcToTrackingMore>();

                    ECSalesOrder model = saleOrderRepository.Query(a => a.ShippingMethodNo == data.express_num, null, x => x.Include(a => a.BnsSendDeliverdToEcs)).FirstOrDefault();
                    Dictionary<string, Object> dic = new Dictionary<string, Object>();
                    if (model != null)
                    {
                        BnsShippingEcToTrackingMore carModel = carryRepository.Query(a => a.Shiping == model.ShippingMethod).FirstOrDefault();
                        dic.Add("trackinfo", model.BnsSendDeliverdToEcs[0].LogisticsDetails);
                        dic.Add("carrier_code", carModel.ServerName);
                        dic.Add("express_num", model.BnsSendDeliverdToEcs[0].ShippingMethodNo);
                        dic.Add("delivered_status", model.BnsSendDeliverdToEcs[0].DeliveredStatus);
                        res.data = dic;
                    }
                    else
                    {
                        res.Status = "false";
                        res.message = "单号不存在";
                    }
                }
            }
            catch (Exception ex)
            {
                res.Status = "fail";
                res.message = ex.Message;
            }

            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelFile"></param>
        [Route("productTrans")]
        [HttpPost]
        public GridPage<List<ProductImportModel>> ProductTrans([FromForm] IFormFile excelFile)
        {
            var res = new GridPage<List<ProductImportModel>> { code = ResCode.Success };
            try
            {
                List<ProductImportModel> list = ExcelHelper<ProductImportModel>.ExcelToList(excelFile);
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repos = uow.GetRepository<ECProduct>();
                    var products = repos.GetAll();
                    List<ProductImportModel> lists = (from a in list
                                                      join d in products on a.sku equals d.ProductSku
                                                      select new ProductImportModel
                                                      {
                                                          sku = a.sku,
                                                          image = d.ProductImages,
                                                          imageUrl = d.ProductImages
                                                      }).ToList();
                    BaseResponse resp = new BaseResponse();
                    Dictionary<string, string>  dic = Web.Framework.Helper.FileHelper.uploadExcel(ExcelHelper<ProductImportModel>.NpoiListToExcel(lists), resp, _hostingEnvironment.ContentRootPath).data;
                    res.data = lists;
                    res.totalCount = lists.Count;
                    string url = "";
                    dic.TryGetValue("url",out url);
                    res.url = url;
                }
            }
            catch (Exception ex)
            {

                res.msg = $"出现异常:{ex.Message}";
                res.code = ResCode.Error;
            }
            return res;
        }
    }
}