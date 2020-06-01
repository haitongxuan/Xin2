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
/// <summary>
/// 头程出库单
/// </summary>
namespace Xin.ExternalService.EC.Job.Init
{
    [DisallowConcurrentExecution]

    public class EcShipBatchInit : EcBaseJob
    {
        private readonly LogHelper log;
        public EcShipBatchInit()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }
        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ECShipBatch>();
                    List<ECShipBatch> insertList = new List<ECShipBatch>();
                    WMSShipBatchReqModel reqModel = new WMSShipBatchReqModel();
                    reqModel.Page = "1";
                    reqModel.PageSize = "50";
                    WMSGetShipBatchRequest req = new WMSGetShipBatchRequest(login.Username, login.Password, reqModel);
                    log.Info($"头程出库单 - 开始拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
                    var response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 50);
                    log.Info($"头程出库单 - 共计{pageNum}页");
                    for (int page = 1; page < pageNum + 1; page++)
                    {
                        reqModel.Page = page.ToString();
                        reqModel.PageSize = "50";
                        log.Info($"头程出库单 - 正在拉取{page}页");
                        req = new WMSGetShipBatchRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                        foreach (var item in response.Body)
                        {
                            var m = Mapper<EC_ShipBatch, ECShipBatch>.Map(item);
                            insertList.Add(m);
                        }
                    }
                    try
                    {
                        insertList = insertList.GroupBy(item => item.OrderCode).Select(item => item.First()).ToList();
                        if (insertList.Count > 0)
                        {
                            await repository.DeleteAll();
                            await uow.SaveChangesAsync();
                        }
                        await repository.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        insertList.Clear();
                        log.Info($"头程出库单 - 拉取完成");
                    }
                    catch (Exception ex)
                    {
                        log.Error($"头程出库单 - 拉取出现异常:{ex.Message}");
                        throw;
                    }
                }
                log.Info($"头程出库单 - 任务完成");
            }
            catch (Exception ex)
            {
                log.Error($"头程出库单 - 拉取出现异常:{ex.Message}");
                throw;
            }
        }
    }
}
