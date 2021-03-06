﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Web.Framework.Controllers;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Web.Framework.Model;
using Xin.Web.Framework.Helper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using Xin.Entities;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECHeadTripController : BaseController<ECHeadTripLine>
    {

        public ECHeadTripController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        /// <summary>
        /// 头程商品信息
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetECFbaHeadTripLinesPage")]
        [HttpPost]
        public GridPage<List<ECHeadTripLine>> GetECHeadTripLinesPage(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<ECHeadTripLine>>() { code = ResCode.Success };
            StringBuilder sbCommon = new StringBuilder();
            StringBuilder sbLoandate = new StringBuilder();
            List<FilterNode> list = new List<FilterNode>();
            foreach (var item in pageReq.query)
            {
                if (item.value != null)
                {
                    switch (item.key.ToLower())
                    {
                        case "addtime":
                            if (item.binaryop == "gt")
                                sbCommon.Append($" and t1.AddTime >= '{item.value}'");
                            if (item.binaryop == "lt")
                                sbCommon.Append($" and t1.AddTime <= '{item.value}'");
                            break;
                        case "itemsku":
                            sbCommon.Append($" and t4.PcrProductSku {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "storename":
                            sbCommon.Append($" and t1.PlatformUserName {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "towarehouse":
                            sbCommon.Append($" and ToWarehouse {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "warehouse":
                            sbCommon.Append($" and Warehouse {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "ordercode":
                            sbCommon.Append($" and t1.Ordercode {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "companyname":
                            sbCommon.Append($" and company {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                    }
                }
            }
            var whereSql = new SqlParameter("@whereSql", sbCommon.ToString());

            res = DataBaseHelper<ECHeadTripLine>.GetFromProcedure(_uowProvider, res, pageReq, false, "EXECUTE ShipBatckQuery_sp @whereSql", whereSql);

            return res;
        }

        /// <summary>
        /// 头程商品信息导出
        /// </summary>
        /// <param name="pageReq"></param>
        [Route("ExportECHeadTripLines")]
        [HttpPost]
        public void ExportECHeadTripLines(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<ECHeadTripLine>>() { code = ResCode.Success };
            StringBuilder sbCommon = new StringBuilder();
            StringBuilder sbLoandate = new StringBuilder();
            List<FilterNode> list = new List<FilterNode>();
            foreach (var item in pageReq.query)
            {
                if (item.value != null)
                {
                    switch (item.key.ToLower())
                    {
                        case "addtime":
                            if (item.binaryop == "gt")
                                sbCommon.Append($" and t1.AddTime >= '{item.value}'");
                            if (item.binaryop == "lt")
                                sbCommon.Append($" and t1.AddTime <= '{item.value}'");
                            break;
                        case "itemsku":
                            sbCommon.Append($" and t4.PcrProductSku {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "storename":
                            sbCommon.Append($" and t1.PlatformUserName {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "towarehouse":
                            sbCommon.Append($" and ToWarehouse {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "warehouse":
                            sbCommon.Append($" and Warehouse {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "ordercode":
                            sbCommon.Append($" and t1.Ordercode {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                        case "companyname":
                            sbCommon.Append($" and company {Operate.GetSqlOperate(item.binaryop)} '{item.value}'");
                            break;
                    }
                }
            }
            var whereSql = new SqlParameter("@whereSql", sbCommon.ToString());

            pageReq.query = list;
            res = DataBaseHelper<ECHeadTripLine>.GetFromProcedure(_uowProvider, res, pageReq, true, "EXECUTE ShipBatckQuery_sp @whereSql", whereSql);
            //将已经解码的字符再次进行编码.
            Response.Headers.Add("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("FinancialStatementReport.xlsx"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8";
            Response.Body.Write(ExcelHelper<ECHeadTripLine>.NpoiListToExcel(res.data.OrderBy(a => a.AddTime).ThenByDescending(a => a.AddTime).ToList()));
            Response.Body.Flush();
            Response.Body.Close();
        }
        /// <summary>
        /// 获取店铺数据
        /// </summary>
        /// <returns></returns>
        [Route("GetShop")]
        [HttpGet]
        public string[] GetShop()
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var reps = uow.GetRepository<ECShipBatch>();
                var sql = reps.GetAll().GroupBy(item => new { item.UserAccount}).ToList();
                string[] shops = new string[sql.Count];
                for (int i = 0; i < sql.Count; i++)
                {
                    shops[i] = sql[i].Key.UserAccount;
                }
                return shops;
            }
        }
    }
}