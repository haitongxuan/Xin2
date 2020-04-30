using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
            bool finish = true;
            int page = 1;
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
                EBGetSkuRelationReqModel reqModel = new EBGetSkuRelationReqModel();
                RelationCondition condition = new RelationCondition();
                condition.AddTimeStart = "2018-01-01";
                condition.AddTimeEnd = "2020-03-10";
                while (finish)
                {
                    reqModel.Page = page;
                    reqModel.PageSize = 5000;
                    reqModel.Condition = condition;
                    EBGetSkuRelationRequest request = new EBGetSkuRelationRequest(login.Username, login.Password, reqModel);
                    var response = await request.Request();
                    System.Diagnostics.Debug.WriteLine($"第{page}页获取成功");
                    if (response.Body.Count == 5000)
                    {
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SkuRelation, ECSkuRelation>.Map(item);
                                m.CreateTime = DateTime.Parse(reqModel.Condition.AddTimeEnd);
                                skuRelation.Add(m);
                            }
                            catch (Exception ex)
                            {
                                RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationInit", "ERROR", "Sku映射转换实体类出现异常;" + ex.Message, reqModel));
                                System.Diagnostics.Debug.WriteLine($"Sku映射转换实体类出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
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
                                m.CreateTime = DateTime.Parse(reqModel.Condition.AddTimeEnd);
                                skuRelation.Add(m);
                            }
                            catch (Exception ex)
                            {
                                RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationInit", "ERROR", "Sku映射转换实体类出现异常;" + ex.Message, reqModel));
                                System.Diagnostics.Debug.WriteLine($"Sku映射转换实体类出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
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
                            RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationInit", "ERROR", "入库单信息,写入数据库异常;" + ex.Message, reqModel));
                            System.Diagnostics.Debug.WriteLine($"入库单信息,写入数据库异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }
                    if (page % 4 == 0 && skuRelation.Count > 0)
                    {
                        try
                        {
                            System.Diagnostics.Debug.WriteLine($"本次写入{skuRelation.Count}条");
                            await repository.BulkInsertAsync(skuRelation, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            skuRelation.Clear();
                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("Xin", "EcGetSkuRelationInit", "ERROR", "入库单信息,写入数据库异常;" + ex.Message, reqModel));
                            System.Diagnostics.Debug.WriteLine($"入库单信息,写入数据库异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }
                    page++;
                }
                //response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                //int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                //for (int page = 1; page < pageNum; page++)
                //{
                //    reqModel.Page = page;
                //    reqModel.PageSize = 1000;
                //    try
                //    {
                //        System.Diagnostics.Debug.WriteLine($"Sku映射,开始拉取,开始时间:{DateTime.Now};时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;");
                //        request = new EBGetSkuRelationRequest(login.Username, login.Password, reqModel);
                //        response =await request.Request();
                //        foreach (var item in response.Body)
                //        {
                //            try
                //            {
                //                var m = Mapper<EC_SkuRelation, ECSkuRelation>.Map(item);
                //                m.CreateTime = DateTime.Parse(reqModel.Condition.AddTimeEnd);
                //                skuRelation.Add(m);
                //            }
                //            catch (Exception ex)
                //            {
                //                System.Diagnostics.Debug.WriteLine($"Sku映射转换实体类出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                //                throw ex;
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        System.Diagnostics.Debug.WriteLine($"Sku映射接口获取出现异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                //        throw ex;
                //    }
                //    try
                //    {
                //        System.Diagnostics.Debug.WriteLine($"拉取结束&开始写入时间时间: { DateTime.Now}");
                //        await repository.BulkInsertAsync(skuRelation, x => x.IncludeGraph = true);
                //        uow.BulkSaveChanges();
                //        skuRelation.Clear();
                //        System.Diagnostics.Debug.WriteLine($"写入完成时间: { DateTime.Now}");
                //    }
                //    catch (Exception ex)
                //    {
                //        System.Diagnostics.Debug.WriteLine($"入库单信息,写入数据库异常:时间区间{reqModel.Condition.AddTimeStart.ToString()}TO{reqModel.Condition.AddTimeEnd.ToString()}第{reqModel.Page}页;异常信息:{ex.Message}");
                //        throw ex;
                //    }
                //}
                //Parallel.ForEach(pages, new ParallelOptions { MaxDegreeOfParallelism = 1 },  page =>  mulitSaveAsync(reqModel,page));
            }
        }
        public void mulitSaveAsync(EBGetSkuRelationReqModel reqModel, int page)
        {

        }
    }
}
