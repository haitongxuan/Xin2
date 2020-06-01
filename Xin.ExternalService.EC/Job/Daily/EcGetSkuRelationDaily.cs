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
using Xin.Repository;

namespace Xin.ExternalService.EC.Job.Daily
{
    [DisallowConcurrentExecution]
    public class EcGetSkuRelationDaily : EcBaseJob
    {
        private readonly LogHelper log;
        public EcGetSkuRelationDaily()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }
        public async override Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {
            bool finish = true;
            int page = 1;
            List<ECSkuRelation> skuRelation = new List<ECSkuRelation>();
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECSkuRelation>();
                datetime = repository.GetPage(0, 1, x => x.OrderByDescending(c => c.CreateTime)).FirstOrDefault().CreateTime;
                EBGetSkuRelationReqModel reqModel = new EBGetSkuRelationReqModel();
                RelationCondition condition = new RelationCondition();
                condition.AddTimeStart = datetime.ToString();
                condition.AddTimeEnd = DateTime.Now.ToString();
                log.Info($"SKU映射信息 - 开始拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" })}");
                while (finish)
                {
                    reqModel.Page = page;
                    reqModel.PageSize = 1000;
                    reqModel.Condition = condition;
                    log.Info($"SKU映射信息 - 正在拉取第{page}页");
                    EBGetSkuRelationRequest request = new EBGetSkuRelationRequest(login.Username, login.Password, reqModel);
                    var response = await request.Request();
                    if (response.Body.Count != 1000)
                    {
                        finish = false;
                    }
                    try
                    {
                        skuRelation = skuRelation.GroupBy(a => a.ProductSku).Select(a => a.First()).ToList();
                        await repository.BulkInsertAsync(skuRelation, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        skuRelation.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"SKU映射信息 - 写入数据库异常:{ex.Message}");
                        throw ex;
                    }
                    page++;
                }
                log.Info($"SKU映射信息 - 任务拉取完成");

            }
        }
    }
}
