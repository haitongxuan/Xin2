using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Common;
using Xin.Entities;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response.Model;
using Xin.Repository;

namespace Xin.ExternalService.EC.Job
{
    public class EcGetSkuRelationInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcGetSkuRelationInit(IUowProvider uowProvider)
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
            _uowProvider = uowProvider;
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            await Job(DateTime.Now);
        }

        public override async Task Job(DateTime? datetime = null)
        {
            EBGetSkuRelationReqModel reqModel = new EBGetSkuRelationReqModel();
            RelationCondition condition = new RelationCondition();
            reqModel.Page = 1;
            reqModel.PageSize = 50;
            condition.AddTimeStart = "2018-01-01";
            condition.AddTimeEnd = DateTime.Now.ToString();
            reqModel.Condition = condition;
            List<ECSkuRelation> skuRelation = new List<ECSkuRelation>();

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECSkuRelation>();
                try
                {
                    await repository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"初始化Sku映射信息,删除Sku映射信息异常:{ex.Message}");
                    throw ex;
                }
                EBGetSkuRelationRequest request = new EBGetSkuRelationRequest("admin", "eccang123456", reqModel);
                var response = await request.Request();
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);

                for (int page = pageNum; page >0 ; page--)
                {
                    reqModel.Page = page;
                    reqModel.PageSize = 1000;
                    try
                    {
                        request = new EBGetSkuRelationRequest("admin", "eccang123456", reqModel);
                        response = await request.Request();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"接口获取出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{page}页;异常信息:{ex.Message}");

                        throw ex;
                    }
                    foreach (var item in response.Body)
                    {
                        try
                        {
                            var m = Mapper<EC_SkuRelation, ECSkuRelation>.Map(item);
                            skuRelation.Add(m);
                        }
                        catch (Exception ex)
                        {
                            log.Error($"转换实体类出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{page}页;异常信息:{ex.Message}");
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
                        log.Error($"入库单信息,写入数据库异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                }
            }
        }
    }
}
