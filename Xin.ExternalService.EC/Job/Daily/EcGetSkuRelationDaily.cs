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
                while (finish)
                {
                    reqModel.Page = page;
                    reqModel.PageSize = 1000;
                    reqModel.Condition = condition;
                    RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetSkuRelationDaily", "INFO", $"SKU映射信息开始拉取,第{page}页", reqModel));
                    log.Info($"SKU映射信息开始拉取,第{page}页");
                    EBGetSkuRelationRequest request = new EBGetSkuRelationRequest(login.Username, login.Password, reqModel);
                    var response = await request.Request();
                    if (response.Body.Count == 1000)
                    {
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SkuRelation, ECSkuRelation>.Map(item);
                                if (repository.Query(a => a.ProductSku == m.ProductSku && a.WarehouseId == m.WarehouseId).FirstOrDefault() == null)
                                {
                                    m.CreateTime = DateTime.Parse(reqModel.Condition.AddTimeEnd);
                                    skuRelation.Add(m);
                                }
                            }
                            catch (Exception ex)
                            {
                                RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationDaily", "ERROR", $"Sku映射转换实体类出现异常:{ex.Message},第{page}页", reqModel));
                                log.Error($"Sku映射转换实体类出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        finish = false;
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SkuRelation, ECSkuRelation>.Map(item);
                                if (repository.Query(a => a.ProductSku == m.ProductSku && a.WarehouseId == m.WarehouseId).FirstOrDefault() == null)
                                {
                                    m.CreateTime = DateTime.Parse(reqModel.Condition.AddTimeEnd);
                                    skuRelation.Add(m);
                                }
                            }
                            catch (Exception ex)
                            {
                                RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationDaily", "ERROR", $"Sku映射转换实体类出现异常:{ex.Message},第{page}页", reqModel));
                                log.Error($"Sku映射转换实体类出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                                throw ex;
                            }
                        }
                        try
                        {
                            await repository.BulkInsertAsync(skuRelation, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            skuRelation.Clear();
                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationDaily", "ERROR", $"入库单信息,写入数据库异常:{ex.Message},第{page}页", reqModel));
                            log.Error($"入库单信息,写入数据库异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }
                    if (page % 5 == 0 && skuRelation.Count > 0)
                    {
                        try
                        {
                            skuRelation = skuRelation.GroupBy(a => a.ProductSku).Select(a => a.First()).ToList();
                            await repository.BulkInsertAsync(skuRelation, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            skuRelation.Clear();
                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationDaily", "ERROR", $"入库单信息,写入数据库异常:{ex.Message},第{page}页" + ex.Message, reqModel));
                            log.Error($"入库单信息,写入数据库异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }
                    page++;
                }
            }
            RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationDaily", "INFO", $"入库单信息,写入完成", null));
        }
    }
}
