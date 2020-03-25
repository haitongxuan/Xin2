using System;
using System.Collections.Generic;
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
        public GridPage<List<WaveBlockReportModel>> GetWeavingBlock(string startTime, string endTime, string type)
        {
            var res = new GridPage<List<WaveBlockReportModel>>() { code = ResCode.Success };

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetCustomRepository<ISaleOrderDetailRepository>();
                    var reslt = repository.GetList(startTime, endTime);
                    string[] plates = new string[] { "aliexpress", "amazon", "ebay", "magento", "magento2", "shopify" };

                    var weavingBlockResult = reslt.Where(a => a.Type != "" && a.Size != "")
                                .GroupBy(a => new { a.Size, a.Plateform, a.Type })
                                .Select(b => new
                                {
                                    Size = b.Key.Size,
                                    Plateform = b.Key.Plateform,
                                    Type = b.Key.Type,
                                    Qty = b.Sum(c => c.Qty)
                                }).ToList();
                    if (type == "发帘")
                    {
                        string[] sizes = new string[] { "8寸", "10寸", "12寸", "14寸", "16寸", "18寸", "20寸", "22寸", "24寸", "26寸", "28寸", "30寸", "32寸" };
                        var weaving = weavingBlockResult.Where(a => a.Type == "发帘").ToList();
                        int total = weaving.Sum(a => a.Qty);
                        List<WaveBlockReportModel> dataList = new List<WaveBlockReportModel>();
                        foreach (var size in sizes)
                        {
                            WaveBlockReportModel tempModel = new WaveBlockReportModel();
                            List<PlatformDetail> tempList = new List<PlatformDetail>();
                            var temp = weaving.Where(a => a.Size == size).ToList();
                            int sizeTotal = temp.Sum(a => a.Qty);
                            tempModel.Total = total == 0 ? 1 : total;
                            tempModel.Size = size;
                            tempModel.SizeTotal = sizeTotal;
                            decimal temp1Dec = (decimal)sizeTotal / total * 100;
                            tempModel.SizeTotalRatio = Math.Round(temp1Dec, 2).ToString() + "%";
                            foreach (var plate in plates)
                            {
                                PlatformDetail temp2 = new PlatformDetail();
                                var plateTotal = weaving.Where(a => a.Plateform == plate).Sum(a => a.Qty);
                                plateTotal = plateTotal == 0 ? 1 : plateTotal;
                                var temp1 = temp.Where(a => a.Plateform == plate).ToList();
                                int plateSizeTotal = temp1.Sum(a => a.Qty);
                                temp2.Plate = plate;
                                temp2.SaleNum = plateSizeTotal;
                                decimal tempDec = (decimal)plateSizeTotal / plateTotal * 100;
                                temp2.SalesRatio = Math.Round(tempDec, 2).ToString() + "%";
                                tempList.Add(temp2);
                            }
                            tempModel.Data = tempList;
                            dataList.Add(tempModel);
                        }
                        res.data = dataList;
                    }
                    else if (type == "发块")
                    {
                        string[] sizes = new string[] { "8寸", "10寸", "12寸", "14寸", "16寸", "18寸", "20寸" };
                        var weaving = weavingBlockResult.Where(a => a.Type == "发块").ToList();
                        int total = weaving.Sum(a => a.Qty);
                        List<WaveBlockReportModel> dataList = new List<WaveBlockReportModel>();
                        foreach (var size in sizes)
                        {
                            WaveBlockReportModel tempModel = new WaveBlockReportModel();
                            List<PlatformDetail> tempList = new List<PlatformDetail>();
                            var temp = weaving.Where(a => a.Size == size).ToList();
                            int sizeTotal = temp.Sum(a => a.Qty);
                            tempModel.Total = total == 0 ? 1 : total;
                            tempModel.Size = size;
                            tempModel.SizeTotal = sizeTotal;
                            decimal temp1Dec = (decimal)sizeTotal / total * 100;
                            tempModel.SizeTotalRatio = Math.Round(temp1Dec, 2).ToString() + "%";
                            foreach (var plate in plates)
                            {
                                PlatformDetail temp2 = new PlatformDetail();
                                var plateTotal = weaving.Where(a => a.Plateform == plate).Sum(a => a.Qty);
                                plateTotal = plateTotal == 0 ? 1 : plateTotal;
                                var temp1 = temp.Where(a => a.Plateform == plate).ToList();
                                int plateSizeTotal = temp1.Sum(a => a.Qty);
                                temp2.Plate = plate;
                                temp2.SaleNum = plateSizeTotal;
                                decimal tempDec = (decimal)plateSizeTotal / plateTotal * 100;
                                temp2.SalesRatio = Math.Round(tempDec, 2).ToString() + "%";
                                tempList.Add(temp2);
                            }
                            tempModel.Data = tempList;
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
        public GridPage<List<BnsOmsReceivingCodeRecord>> GetDensity(string startTime, string endTime)
        {
            var res = new GridPage<List<BnsOmsReceivingCodeRecord>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<ISaleOrderDetailRepository>();
                var tt = repository.GetList(startTime, endTime);
                var rr = tt.Where(a => a.HandArea != null)
                    .GroupBy(a => new { a.Style, a.Plateform, a.Density, a.HandArea })
                    .Select(b => new
                    {
                        Style = b.Key.Style,
                        Plateform = b.Key.Plateform,
                        Density = b.Key.Density,
                        HandArea = b.Key.HandArea,
                        Qty = b.Sum(c => c.Qty)
                    }).ToList();

            }

            return res;
        }
    }
}