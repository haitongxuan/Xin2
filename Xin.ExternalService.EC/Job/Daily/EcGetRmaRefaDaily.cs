using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xin.Common;
using Xin.Entities;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Job.Daily
{
    public class EcGetRmaRefaDaily : EcBaseJob
    {
        private readonly LogHelper log;
        public EcGetRmaRefaDaily()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECRmaRefa>();
                EBRmaRefaListReqModel reqModel = new EBRmaRefaListReqModel();
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                reqModel.CreateDateFrom = DateTime.Parse(repository.GetPage(0, 1, x => x.OrderByDescending(c => c.CreateDate)).FirstOrDefault().CreateDate);
                reqModel.CreateDateEnd = DateTime.Now;
                log.Info($"退货重发 - 开始拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
                EBRmaRefaRequest req = new EBRmaRefaRequest(login.Username, login.Password, reqModel);
                var response = await req.Request();
                List<ECRmaRefa> insertList = new List<ECRmaRefa>();
                List<ECRmaRefa> updateList = new List<ECRmaRefa>();
                //新增
                try
                {
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    log.Info($"退货重发 - 共计{pageNum}页");
                    for (int page = 1; page < pageNum + 1; page++)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;
                        log.Info($"退货重发 - 正在拉取{page}页");
                        req = new EBRmaRefaRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                        foreach (var item in response.Body)
                        {
                            var m = Mapper<EC_RmaRefa, ECRmaRefa>.Map(item);
                            if (repository.Query(a => a.OldOrderId == item.OldOrderId && a.Sku == item.Sku && a.Qty == item.Qty).FirstOrDefault() == null)
                            {
                                insertList.Add(m);
                            }
                            else
                            {
                                updateList.Add(m);
                            }
                        }
                    }
                    try
                    {
                        insertList = insertList.GroupBy(item => new { item.OldOrderId, item.Sku ,item.Qty }).Select(item => item.First()).ToList();
                        updateList = updateList.GroupBy(item => new { item.OldOrderId, item.Sku, item.Qty }).Select(item => item.First()).ToList();
                        await repository.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                        await repository.BulkUpdateAsync(updateList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        insertList.Clear();
                        updateList.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"退货重发 - 写入到数据库出现异常:{ex.Message}");
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"退货重发新增出现异常:{ex.Message};参数:{JsonConvert.SerializeObject(reqModel)}");

                    throw;
                }
                //审核时间始更新 
                reqModel.CreateDateFrom = null;
                reqModel.CreateDateEnd = null;
                reqModel.VerifyDateFrom = DateTime.Now.AddDays(-2);
                reqModel.VerifyDateFrom = DateTime.Now;
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                req = new EBRmaRefaRequest(login.Username, login.Password, reqModel);
                log.Info($"退货重发 - 开始根据审核时间拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
                response = await req.Request();
                try
                {
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    log.Info($"退货重发 - 共计{pageNum}页");
                    for (int page = 1; page < pageNum + 1; page++)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;
                        req = new EBRmaRefaRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                        foreach (var item in response.Body)
                        {
                            var m = Mapper<EC_RmaRefa, ECRmaRefa>.Map(item);
                            updateList.Add(m);
                        }
                    }
                    try
                    {
                        updateList = updateList.GroupBy(item => new { item.OldOrderId, item.Sku, item.Qty }).Select(item => item.First()).ToList();
                        await repository.BulkUpdateAsync(updateList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        updateList.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"退货重发 - 写入到数据库出现异常:{ex.Message}");
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"退货重发 - 出现异常:{ex.Message}");
                    throw;
                }
                //重发单发货时间

                reqModel.VerifyDateFrom = null;
                reqModel.VerifyDateFrom = null;
                reqModel.DateWarehouseShippingFrom = DateTime.Now.AddDays(-2);
                reqModel.DateWarehouseShippingTo = DateTime.Now;
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                req = new EBRmaRefaRequest(login.Username, login.Password, reqModel);
                log.Info($"退货重发 - 开始根据重发单发货时间拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");

                response = await req.Request();
                try
                {
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    log.Info($"退货重发 - 共计{pageNum}页");

                    for (int page = 1; page < pageNum + 1; page++)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;
                        req = new EBRmaRefaRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                        foreach (var item in response.Body)
                        {
                            var m = Mapper<EC_RmaRefa, ECRmaRefa>.Map(item);
                            updateList.Add(m);
                        }
                    }
                    try
                    {
                        updateList = updateList.GroupBy(item => new { item.OldOrderId, item.Sku, item.Qty }).Select(item => item.First()).ToList();
                        await repository.BulkUpdateAsync(updateList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        updateList.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"退货重发 - 写入到数据库出现异常:{ex.Message};");
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"退货重发 - 出现异常:{ex.Message};");
                    throw;
                }
            }
            log.Info($"退货重发 - 任务拉取完成");
        }
    }
}
