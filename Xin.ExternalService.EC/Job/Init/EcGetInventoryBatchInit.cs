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
                await repository.DeleteAll();
                await uow.SaveChangesAsync();
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetInventoryBatchInit", "INFO", $"批次库存开始拉取", null ));
                WMSInventoryBatchReqModel reqModel = new WMSInventoryBatchReqModel();
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                reqModel.FifoTimeFrom = DateTime.Parse("2020-03-16");
                reqModel.FifoTimeTo = DateTime.Now;
                WMSInventoryBatchRequest req = new WMSInventoryBatchRequest(login.Username, login.Password, reqModel);
                var response = await req.Request();
                response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                List<ECInventoryBatch> insertList = new List<ECInventoryBatch>();

                for (int page = 1; page < pageNum + 1; page++)
                {
                    reqModel.Page = page;
                    reqModel.PageSize = 1000;
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
                        insertList.Clear();
                    }
                    catch (Exception ex)
                    {
                        RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetInventoryBatchInit", "ERROR", $"批次库存拉取出现异常{ex.Message}", reqModel));
                        throw;
                    }
                }
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetInventoryBatchInit", "INFO", $"批次库存拉取完成", reqModel));

            }

        }
    }
}
