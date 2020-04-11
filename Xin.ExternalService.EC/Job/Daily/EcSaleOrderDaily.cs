using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using Xin.Common;
using Xin.Entities;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response.Model;
using Xin.Repository;
using Xin.Service.Context;

namespace Xin.ExternalService.EC.Job
{
    [DisallowConcurrentExecution]
    public class EcSaleOrderDaily : EcBaseJob
    {
        private readonly LogHelper log;
        public EcSaleOrderDaily()
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
                List<ECSalesOrder> insertList = new List<ECSalesOrder>();
                List<ECSalesOrder> updateList = new List<ECSalesOrder>();
                EBGetOrderListReqModel reqModel = new EBGetOrderListReqModel();
                Conditions reqCondition = new Conditions();
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                reqModel.GetDetail = IsOrNotEnum.Yes;
                reqModel.GetAddress = IsOrNotEnum.Yes;
                reqCondition.CreatedDateBefore = DateTime.Now;
                reqModel.Condition = reqCondition;
                using (var uow = _uowProvider.CreateUnitOfWork(false, false))
                {
                    var repository = uow.GetRepository<ECSalesOrder>();
                    //reqCondition.CreatedDateAfter = DateTime.Parse("2020-03-12T10:50:09");
                    reqCondition.CreatedDateAfter = repository.GetPage(0, 1, x => x.OrderByDescending(c => c.CreatedDate)).FirstOrDefault().CreatedDate;
                    var updateTime = repository.GetPage(0, 1, x => x.OrderByDescending(c => c.UpdateDate)).FirstOrDefault().UpdateDate;
                    //新增
                    Reqeust.EBGetOrderListRequest req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    var response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "INFO", "开始拉取新增数据", reqModel));

                    for (int page = pageNum; page > 0; page--)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;
                        try
                        {
                            log.Info($"日订单开始拉取:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;");
                            req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                            log.Info(JsonConvert.SerializeObject(response.Body));
                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "ERROR", $"订单信息,接口调用出现异常:{ex.Message},第{page}页", reqModel));
                            log.Error($"日订单信息,接口调用出现异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);
                                var had = repository.Get(m.OrderId, x => x.Include(a => a.BnsSendDeliverdToEcs));

                                if (had != null)
                                {
                                    List<BnsSendDeliverdToEc> templist = new List<BnsSendDeliverdToEc>();
                                    had.BnsSendDeliverdToEcs[0].ShippingMethodNo = m.ShippingMethodNo;
                                    had.BnsSendDeliverdToEcs[0].PlatformShipTime = m.PlatformShipTime;
                                    templist.Add(had.BnsSendDeliverdToEcs[0]);
                                    m.BnsSendDeliverdToEcs = templist;
                                    updateList.Add(m);
                                }
                                else
                                {
                                    List<BnsSendDeliverdToEc> templist = new List<BnsSendDeliverdToEc>();
                                    BnsSendDeliverdToEc temp = new BnsSendDeliverdToEc();
                                    temp.ShippingMethodNo = m.ShippingMethodNo;
                                    temp.PlatformShipTime = m.PlatformShipTime;
                                    templist.Add(temp);
                                    m.BnsSendDeliverdToEcs = templist;
                                    insertList.Add(m);
                                }
                            }
                            catch (Exception ex)
                            {
                                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "ERROR", $"订单信息,转换实体类出现异常:{ex.Message},第{page}页", reqModel));
                                log.Error($"日订单信息,转换实体类出现异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;异常信息:{ex.Message}");
                                throw ex;
                            }
                        }
                        //写入数据库
                        try
                        {
                            insertList = insertList.GroupBy(item => item.OrderId).Select(item => item.First()).ToList();
                            updateList = updateList.GroupBy(item => item.OrderId).Select(item => item.First()).ToList();
                            await repository.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                            await repository.BulkUpdateAsync(updateList, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            insertList.Clear();
                            updateList.Clear();

                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "ERROR", $"订单信息,写入数据库异常:{ex.Message},第{page}页", reqModel));
                            log.Error($"订单信息,写入数据库异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()};异常信息:{ex.Message}");
                            throw ex;
                        }
                    }

                    reqCondition.CreatedDateBefore = null;
                    reqCondition.CreatedDateAfter = null;
                    reqCondition.UpdateDateBefore = DateTime.Now;
                    reqCondition.UpdateDateAfter = updateTime;
                    reqModel.Page = 1;
                    reqModel.PageSize = 10;
                    req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "INFO", "开始拉取更新数据", reqModel));

                    for (int page = pageNum; page > 0; page--)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;

                        try
                        {
                            log.Info($"日订单开始更新:更新时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;");
                            req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                            log.Info(response.Body);
                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "ERROR", $"订单信息,接口调用出现异常:{ex.Message},第{page}页", reqModel));
                            log.Error($"订单更新信息,接口调用出现异常:时间区间{reqModel.Condition.UpdateDateBefore.ToString()}TO{reqModel.Condition.UpdateDateAfter.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);
                                var had = repository.Get(m.OrderId, x => x.Include(a => a.BnsSendDeliverdToEcs));
                                if (had != null)
                                {
                                    List<BnsSendDeliverdToEc> templist = new List<BnsSendDeliverdToEc>();
                                    had.BnsSendDeliverdToEcs[0].ShippingMethodNo = m.ShippingMethodNo;
                                    had.BnsSendDeliverdToEcs[0].PlatformShipTime = m.PlatformShipTime;
                                    templist.Add(had.BnsSendDeliverdToEcs[0]);
                                    m.BnsSendDeliverdToEcs = templist;
                                    updateList.Add(m);
                                }
                            }
                            catch (Exception ex)
                            {
                                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "ERROR", $"订单信息,转换实体类出现异常:{ex.Message},第{page}页", null));
                                log.Error($"订单信息,转换实体类出现异常:时间区间{reqModel.Condition.UpdateDateAfter.ToString()}TO{reqModel.Condition.UpdateDateBefore.ToString()}第{page}页;异常信息:{ex.Message}");
                                throw ex;
                            }

                        }
                        //写入数据库
                        try
                        {
                            updateList = updateList.GroupBy(item => item.OrderId).Select(item => item.First()).ToList();
                            await repository.BulkUpdateAsync(updateList, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            updateList.Clear();

                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "ERROR", $"订单信息,出现异常:{ex.Message},第{page}页", reqModel));
                            log.Error($"订单信息,写入数据库异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()};异常信息:{ex.Message}");
                            throw ex;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "ERROR", $"订单信息,出现异常:{ex.Message}", null));
                throw ex;
            }
            RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcSaleOrderDaily", "INFO", "订单信息更新成功", null));

            log.Info($"订单信息更新成功");
        }
    }
}
