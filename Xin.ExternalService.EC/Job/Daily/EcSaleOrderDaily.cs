﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Common;
using Xin.Entities;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Reqeust.Model;
using Xin.ExternalService.EC.Response.Model;
using Xin.Repository;

namespace Xin.ExternalService.EC.Job
{
    public class EcSaleOrderDaily : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcSaleOrderDaily(IUowProvider uowProvider)
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
            _uowProvider = uowProvider;
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
                using (var uow = _uowProvider.CreateUnitOfWork(false))
                {
                    var repository = uow.GetRepository<ECSalesOrder>();
                    reqCondition.CreatedDateAfter = repository.GetPage(0, 1, x => x.OrderByDescending(c => c.CreatedDate)).FirstOrDefault().CreatedDate;

                    //新增
                    Reqeust.EBGetOrderListRequest req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    var response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    for (int page = pageNum; page > 0; page--)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;

                        try
                        {
                            log.Info($"日订单开始拉取:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;");
                            req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                            System.Diagnostics.Debug.WriteLine($"正在拉取{page}页");
                        }
                        catch (Exception ex)
                        {
                            log.Error($"日订单信息,接口调用出现异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);
                                if (repository.Get(m.OrderId) != null)
                                {
                                    updateList.Add(m);
                                }
                                else
                                {
                                    insertList.Add(m);
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error($"日订单信息,转换实体类出现异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;异常信息:{ex.Message}");
                                throw ex;
                            }
                        }
                    }
                    reqCondition.CreatedDateBefore = null;
                    reqCondition.CreatedDateAfter = null;
                    reqCondition.UpdateDateBefore = DateTime.Now;
                    reqCondition.UpdateDateAfter = repository.GetPage(0, 1, x => x.OrderByDescending(c => c.UpdateDate)).FirstOrDefault().UpdateDate;
                    reqModel.Page = 1;
                    reqModel.PageSize = 10;
                    req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    for (int page = pageNum; page > 0; page--)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;

                        try
                        {
                            log.Info($"日订单开始更新:更新时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;");
                            req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                            System.Diagnostics.Debug.WriteLine($"正在拉取{page}页");

                        }
                        catch (Exception ex)
                        {
                            log.Error($"订单更新信息,接口调用出现异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);
                                updateList.Add(m);
                            }
                            catch (Exception ex)
                            {
                                log.Error($"订单信息,转换实体类出现异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()}第{page}页;异常信息:{ex.Message}");
                                throw ex;
                            }
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
                        log.Error($"订单信息,写入数据库异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()};异常信息:{ex.Message}");
                        throw ex;
                    }

                    //写入数据库
                    try
                    {
                        insertList = insertList.GroupBy(item => item.OrderId).Select(item => item.First()).ToList();
                        await repository.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        insertList.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"订单信息,写入数据库异常:时间区间{reqModel.Condition.CreatedDateBefore.ToString()}TO{reqModel.Condition.CreatedDateAfter.ToString()};异常信息:{ex.Message}");
                        throw ex;
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            log.Info($"订单信息更新成功");
        }
    }
}