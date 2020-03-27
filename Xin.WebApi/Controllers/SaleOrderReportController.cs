using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Entities;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Service;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Model;

namespace Xin.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderReportController : BaseController<BnsOmsReceivingCodeRecord>
    {
        public SaleOrderReportController(IUowProvider uowProvider) : base(uowProvider)
        {
        }
        [Route("GetWeavingBlock")]
        [HttpPost]
        public GridPage<List<WaveBlockReportModel>> GetWeavingBlock([FromBody]ReqTimeBetween req)
        {
            var res = new GridPage<List<WaveBlockReportModel>>() { code = ResCode.Success };
            DateTime dt = DateTime.Now;
            string startTime = req.startTime;
            string endTime = req.endTime;
            string type = req.type;
            if (string.IsNullOrEmpty(startTime))
            {
                startTime = dt.AddDays(1 - dt.Day).Date.ToString();
            }
            if (string.IsNullOrEmpty(endTime))
            {
                endTime = dt.AddDays(1 - dt.Day).AddMonths(1).Date.ToString();
            }
            else
            {
                endTime = DateTime.Parse(endTime).AddDays(1).Date.ToString();
            }
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<SaleOrderDetail>(); ;
                    var sdatep = new SqlParameter("@startDate", startTime);
                    var edatep = new SqlParameter("@endDate", endTime);
                    var sqltype = new SqlParameter("@type", type);
                    string[] plates = new string[] { "aliexpress", "amazon", "ebay", "magento", "shopify" };

                    if (type == "发帘")
                    {
                        var weaving = repository.FromProcedure("EXECUTE GetOrderDetail @startDate,@endDate,@type", sdatep, edatep, sqltype).ToList();
                        string[] sizes = new string[] { "8寸", "10寸", "12寸", "14寸", "16寸", "18寸", "20寸", "22寸", "24寸", "26寸", "28寸", "30寸", "32寸" };
                        int total = weaving.Where(a=>a.Size!=null).Sum(a => a.Qty);
                        List<WaveBlockReportModel> dataList = new List<WaveBlockReportModel>();
                        foreach (var size in sizes)
                        {
                            WaveBlockReportModel tempModel = new WaveBlockReportModel();
                            var temp = weaving.Where(a => a.Size == size).ToList();
                            int sizeTotal = temp.Sum(a => a.Qty);
                            tempModel.Total = total == 0 ? 1 : total;
                            tempModel.Size = size;
                            tempModel.SizeTotal = sizeTotal;
                            decimal temp1Dec = (decimal)sizeTotal / total * 100;
                            tempModel.SizeTotalRatio = Math.Round(temp1Dec, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                            foreach (string plate in plates)
                            {
                                var plateTotal = weaving.Where(a => a.Plateform.Contains(plate)).Sum(a => a.Qty);
                                plateTotal = plateTotal == 0 ? 1 : plateTotal;
                                var temp1 = temp.Where(a => a.Plateform == plate).ToList();
                                int plateSizeTotal = temp1.Sum(a => a.Qty);
                                decimal tempDec = (decimal)plateSizeTotal / plateTotal * 100;
                                var tempRatio = Math.Round(tempDec, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                                switch (plate)
                                {
                                    case "aliexpress":
                                        tempModel.aliSizeTotal = plateSizeTotal;
                                        tempModel.aliSizeTotalRatio = tempRatio;
                                        break;
                                    case "amazon":
                                        tempModel.amazSizeTotal = plateSizeTotal;
                                        tempModel.amazSizeTotalRatio = tempRatio; break;
                                    case "ebay":
                                        tempModel.ebaySizeTotal = plateSizeTotal;
                                        tempModel.ebaySizeTotalRatio = tempRatio; break;
                                    case "magento":
                                        tempModel.magentoSizeTotal = plateSizeTotal;
                                        tempModel.magentoSizeTotalRatio = tempRatio; break;
                                    case "shopify":
                                        tempModel.shopifySizeTotal = plateSizeTotal;
                                        tempModel.shopifySizeTotalRatio = tempRatio;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            dataList.Add(tempModel);
                        }
                        res.data = dataList;
                    }
                    else if (type == "发块")
                    {
                        string[] sizes = new string[] { "8寸", "10寸", "12寸", "14寸", "16寸", "18寸", "20寸" };
                        var weaving = repository.FromProcedure("EXECUTE GetOrderDetail @startDate,@endDate,@type", sdatep, edatep, sqltype).ToList();
                        int total = weaving.Where(a => a.Size != null).Sum(a => a.Qty);
                        List<WaveBlockReportModel> dataList = new List<WaveBlockReportModel>();
                        foreach (var size in sizes)
                        {
                            WaveBlockReportModel tempModel = new WaveBlockReportModel();
                            var temp = weaving.Where(a => a.Size == size).ToList();
                            int sizeTotal = temp.Sum(a => a.Qty);
                            tempModel.Total = total == 0 ? 1 : total;
                            tempModel.Size = size;
                            tempModel.SizeTotal = sizeTotal;
                            decimal temp1Dec = (decimal)sizeTotal / total * 100;
                            tempModel.SizeTotalRatio = Math.Round(temp1Dec, 2).ToString() + "%";
                            foreach (string plate in plates)
                            {
                                var plateTotal = weaving.Where(a => a.Plateform.Contains(plate)).Sum(a => a.Qty);
                                plateTotal = plateTotal == 0 ? 1 : plateTotal;
                                var temp1 = temp.Where(a => a.Plateform == plate).ToList();
                                int plateSizeTotal = temp1.Sum(a => a.Qty);
                                decimal tempDec = (decimal)plateSizeTotal / plateTotal * 100;
                                var tempRatio = Math.Round(tempDec, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                                switch (plate)
                                {
                                    case "aliexpress":
                                        tempModel.aliSizeTotal = plateSizeTotal;
                                        tempModel.aliSizeTotalRatio = tempRatio;
                                        break;
                                    case "amazon":
                                        tempModel.amazSizeTotal = plateSizeTotal;
                                        tempModel.amazSizeTotalRatio = tempRatio; break;
                                    case "ebay":
                                        tempModel.ebaySizeTotal = plateSizeTotal;
                                        tempModel.ebaySizeTotalRatio = tempRatio; break;
                                    case "magento":
                                        tempModel.magentoSizeTotal = plateSizeTotal;
                                        tempModel.magentoSizeTotalRatio = tempRatio; break;
                                    case "shopify":
                                        tempModel.shopifySizeTotal = plateSizeTotal;
                                        tempModel.shopifySizeTotalRatio = tempRatio;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            dataList.Add(tempModel);
                        }
                        res.data = dataList;
                    }
                    else
                    {
                        res.code = ResCode.ServerError;
                        res.msg = "Type不能为空";
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
        [Route("GetDensity")]
        [HttpPost]
        public GridPage<List<DensityReportModel>> GetDensity([FromBody]string startTime, string endTime)
        {
            DateTime dt = DateTime.Now;
            if (string.IsNullOrEmpty(startTime))
            {
                startTime = dt.AddDays(1 - dt.Day).Date.ToString();
            }
            if (string.IsNullOrEmpty(endTime))
            {
                endTime = dt.AddDays(1 - dt.Day).AddMonths(1).Date.ToString();
            }
            else
            {
                endTime = DateTime.Parse(endTime).AddDays(1).Date.ToString();
            }
            var res = new GridPage<List<DensityReportModel>>() { code = ResCode.Success };
            try
            {

                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<SaleOrderDetail>(); ;
                    var sdatep = new SqlParameter("@startDate", startTime);
                    var edatep = new SqlParameter("@endDate", endTime);
                    var sqltype = new SqlParameter("@type", "头套");
                    var allResult = repository.FromProcedure("EXECUTE GetOrderDetail @startDate,@endDate,@type", sdatep, edatep, sqltype).ToList();
                    var result = allResult.Where(a => a.HandArea != null).ToList();
                    string[] handAreas = new string[] { "13*4|130%", "13*4|150%", "13*4|180%", "13*6|150%", "13*6|180%", "13*6|250%", "360|150%", "360|180%", "4*4|150%", "4*4|180%", "机制|130%", "机制|" };
                    string[] styles = new string[] { "ST", "BW", "WW", "KC", "KS", "JC", "DW", "LW", "NW", "BOB", "BJC", "BKC", "BWW", "BST", "BST", "OBB", "0PT", "小配件", "上海头", "爆炸头", "MXC", "LJC", "18-WIG49-N", "OBH", "ALW", "其它" };
                    List<DensityReportModel> list = new List<DensityReportModel>();
                    foreach (var style in styles)
                    {
                        DensityReportModel tempModel = new DensityReportModel();
                        var temp = result.Where(a => a.Style == style).ToList();
                        tempModel.Total = temp.Sum(a => a.Qty);
                        tempModel.Style = style;
                        foreach (var handArea in handAreas)
                        {
                            string area = string.Empty;
                            string denty = string.Empty;
                            string[] hang = handArea.Split("|");
                            area = hang[0];
                            denty = hang[1] == "" ? null : hang[1];
                            var tempList = temp.Where(a => a.Density == denty && a.HandArea == area).ToList();
                            int sum = tempList.Sum(a => a.Qty);
                            switch (handArea)
                            {
                                case "13*4|130%":
                                    tempModel.Density134130Total = sum;
                                    break;
                                case "13*4|150%":
                                    tempModel.Density134150Total = sum;
                                    break;
                                case "13*4|180%":
                                    tempModel.Density134180Total = sum;
                                    break;
                                case "13*6|150%":
                                    tempModel.Density136150Total = sum;
                                    break;
                                case "13*6|180%":
                                    tempModel.Density136180Total = sum;
                                    break;
                                case "13*6|250%":
                                    tempModel.Density136250Total = sum;
                                    break;
                                case "360|150%":
                                    tempModel.Density360150Total = sum;
                                    break;
                                case "360|180%":
                                    tempModel.Density360180Total = sum;
                                    break;
                                case "全手织|150%":
                                    tempModel.DensityHand150Total = sum;
                                    break;
                                case "全手织|180%":
                                    tempModel.DensityHand180Total = sum;
                                    break;
                                case "4*4|150%":
                                    tempModel.Density44150Total = sum;
                                    break;
                                case "4*4|180%":
                                    tempModel.Density44180Total = sum;
                                    break;
                                case "机制|130%":
                                    tempModel.DensityMachine130Total = sum;
                                    break;
                                case "机制|":
                                    tempModel.DensityMachineTotal = sum;
                                    break;

                                default:
                                    break;
                            }
                        }
                        list.Add(tempModel);
                    }
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

        [Route("GetOddMinusSale")]
        [HttpPost]
        public GridPage<List<OddMinusSale>> GetOddMinusSale(string startTime, string endTime)
        {
            var res = new GridPage<List<OddMinusSale>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var sdatep = new SqlParameter("@Sdate", startTime);
                    var edatep = new SqlParameter("@Edate", endTime);

                    var repository = uow.GetRepository<OddMinusSale>();
                    var data = repository.FromProcedure("EXECUTE OddMinusSale_sp @Sdate,@Edate", sdatep, edatep).ToList();
                    res.data = data;
                    return res;
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