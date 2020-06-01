using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xin.Common;
using Xin.Entities;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response.Model;
using Xin.Repository;

namespace Xin.ExternalService.EC.Job.Init
{
    [DisallowConcurrentExecution]

    public class EcGetInventoryBatchInit : EcBaseJob
    {
        private readonly LogHelper log;

        public EcGetInventoryBatchInit()
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
                var repository = uow.GetRepository<ECInventoryBatch>();
                var warehouse = uow.GetRepository<ECWarehouse>();
                List<ECWarehouse> warehouseList = warehouse.GetAll().ToList();
                List<ECInventoryBatch> allList = new List<ECInventoryBatch>();
                await repository.DeleteAll();
                await uow.SaveChangesAsync();
                WMSInventoryBatchReqModel reqModel = new WMSInventoryBatchReqModel();
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                reqModel.FifoTimeFrom = DateTime.Parse("2016-04-15");
                reqModel.FifoTimeTo = DateTime.Now;
                WMSInventoryBatchRequest req = new WMSInventoryBatchRequest(login.Username, login.Password, reqModel);
                log.Info($"批次入库单 - 开始获取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" })}");
                var response = await req.Request();
                response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                List<ECInventoryBatch> insertList = new List<ECInventoryBatch>();

                for (int page = 1; page < pageNum + 1; page++)
                {
                    reqModel.Page = page;
                    reqModel.PageSize = 1000;
                    log.Info($"批次入库单 - 正在获取{page}页");
                    req = new WMSInventoryBatchRequest(login.Username, login.Password, reqModel);
                    response = await req.Request();
                    foreach (var item in response.Body)
                    {
                        var m = Mapper<EC_InventoryBatch, ECInventoryBatch>.Map(item);
                        insertList.Add(m);
                    }

                    try
                    {
                        insertList = insertList.GroupBy(item => new { item.RoCode, item.ProductSku }).Select(item => item.First()).ToList();
                        await repository.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        allList.AddRange(insertList);
                        insertList.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"批次入库单 - 写入数据库出现异常:{ex.Message}");
                        throw;
                    }
                }
                log.Info("批次入库单 - 任务完成");
            }

        }
    }
}
