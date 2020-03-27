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
                    var repository = uow.GetRepository<WavingBlock>(); ;
                    var sdatep = new SqlParameter("@startDate", startTime);
                    var edatep = new SqlParameter("@endDate", endTime);
                    var sqltype = new SqlParameter("@type", type);
                    var weaving = repository.FromProcedure("EXECUTE GetWavingBlock_sp @startDate,@endDate,@type", sdatep, edatep, sqltype).ToList();
                    int total = 0;
                    List<WaveBlockReportModel> dataList = new List<WaveBlockReportModel>();
                    foreach (var item in weaving)
                    {
                        int tempNum = item.Magento + item.Shopify + item.Aliexpress + item.Amazon + item.Ebay;
                        total += tempNum;
                        WaveBlockReportModel model = new WaveBlockReportModel();
                        model.Size = item.Size;
                        model.SizeTotal = tempNum;
                        model.shopifySizeTotal = item.Shopify;
                        model.shopifySizeTotalRatio = item.ShopifyTotalRatio.ToString() + "%";
                        model.aliSizeTotal = item.Aliexpress;
                        model.aliSizeTotalRatio = item.AliexpressTotalRatio.ToString() + "%";
                        model.ebaySizeTotal = item.Ebay;
                        model.ebaySizeTotalRatio = item.EbayTotalRatio.ToString() + "%";
                        model.amazSizeTotal = item.Amazon;
                        model.amazSizeTotalRatio = item.AmazonTotalRatio.ToString() + "%";
                        model.magentoSizeTotal = item.Magento;
                        model.magentoSizeTotalRatio = item.MagentoTotalRatio.ToString() + "%";
                        dataList.Add(model);
                    }
                    foreach (var item in dataList)
                    {
                        item.Total = total;
                        decimal tempDec = (decimal)item.SizeTotal / item.Total * 100;
                        item.SizeTotalRatio = Math.Round(tempDec, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                    }
                    res.data = dataList;
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
        public GridPage<List<DensityReportModel>> GetDensity([FromBody]ReqTimeBetween req)
        {
            DateTime dt = DateTime.Now;
            string startTime = req.startTime;
            string endTime = req.endTime;
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
                    var repository = uow.GetRepository<HeadgearDensity>(); ;
                    var sdatep = new SqlParameter("@startDate", startTime);
                    var edatep = new SqlParameter("@endDate", endTime);
                    var result = repository.FromProcedure("EXECUTE GetHeadgearDensity_sp @startDate,@endDate", sdatep, edatep).ToList();
                    List<DensityReportModel> list = new List<DensityReportModel>();

                    foreach (var item in result)
                    {
                        DensityReportModel model = new DensityReportModel();
                        model.Style = item.Style;
                        model.Total = item.Density134130 + item.Density134150 + item.Density134180
                            + item.Density136130 + item.Density136150 + item.Density136180 + item.Density136250
                            + item.Density360130 + item.Density360150 + item.Density360180 + item.Density360250
                            + item.Density44130 + item.Density44150 + item.Density44180
                            + item.DensityHand130 + item.Densityhand150 + item.Densityhand180
                            + item.Densitymachine + item.Densitymachine130;
                        model.Density134130Total = item.Density134130;
                        model.Density134150Total = item.Density134150;
                        model.Density134180Total = item.Density134180;
                        model.Density136130Total = item.Density136130;
                        model.Density136150Total = item.Density136150;
                        model.Density136180Total = item.Density136180;
                        model.Density136250Total = item.Density136250;
                        model.Density360130Total = item.Density360130;
                        model.Density360150Total = item.Density360150;
                        model.Density360180Total = item.Density360180;
                        model.Density360250Total = item.Density360250;
                        model.Density44130Total = item.Density44130;
                        model.Density44150Total = item.Density44150;
                        model.Density44180Total = item.Density44180;
                        model.DensityHand130Total = item.DensityHand130;
                        model.DensityHand150Total = item.Densityhand150;
                        model.DensityHand180Total = item.Densityhand180;
                        model.DensityMachine130Total = item.Densitymachine;
                        model.DensityMachineTotal = item.Densitymachine130;
                        list.Add(model);
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
        public GridPage<List<OddMinusSale>> GetOddMinusSale([FromBody]ReqTimeBetween req)
        {
            var res = new GridPage<List<OddMinusSale>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var sdatep = new SqlParameter("@Sdate", req.startTime);
                    var edatep = new SqlParameter("@Edate", req.endTime);

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

        [Route("GetDensityStyle")]
        [HttpGet]
        public string[] GetDensityStyle()
        {
            string[] styles = new string[] { "ST", "BW", "WW", "KC", "KS", "JC", "DW", "LW", "NW", "BOB", "BJC", "BKC", "BWW", "BST", "BST", "OBB", "0PT", "小配件", "上海头", "爆炸头", "MXC", "LJC", "18-WIG49-N", "OBH", "ALW", "其它" };
            return styles;
        }
    }
}