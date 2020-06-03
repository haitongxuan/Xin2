using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
                List<ECSalesOrder> tempList = new List<ECSalesOrder>();
                EBGetOrderListReqModel reqModel = new EBGetOrderListReqModel();
                Conditions reqCondition = new Conditions();
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                reqModel.GetDetail = IsOrNotEnum.Yes;
                reqModel.GetAddress = IsOrNotEnum.Yes;
                reqCondition.CreatedDateBefore = DateTime.Now;
                //List<string> list = new List<string>();
                //list.Add("8014690641387899");
                //reqCondition.RefNos = list;
                reqModel.Condition = reqCondition;
                using (var uow = _uowProvider.CreateUnitOfWork(false, false))
                {
                    var repository = uow.GetRepository<ECSalesOrder>();
                    var rep = uow.GetRepository<ECSalesOrderAddress>();
                    //reqCondition.CreatedDateAfter = DateTime.Parse("2020-05-24");
                    reqCondition.CreatedDateAfter = ((DateTime)repository.GetPage(0, 1, x => x.OrderByDescending(c => c.CreatedDate)).FirstOrDefault().CreatedDate).AddHours(-3);
                    var updateTime = ((DateTime)repository.GetPage(0, 1, x => x.OrderByDescending(c => c.UpdateDate)).FirstOrDefault().UpdateDate).AddHours(-3);
                    //新增
                    Reqeust.EBGetOrderListRequest req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    log.Info($"订单新增数据 - 开始获取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" })}");
                    var response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    log.Info($" 订单新增数据 - 共计{pageNum}页");
                    for (int page = 1; page < pageNum + 1; page++)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;
                        try
                        {
                            log.Info($"订单新增数据 - 正在拉取第{page}页");
                            req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"订单新增数据 - 接口调用出现异常:{ex.Message}");
                            throw ex;
                        }
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);
                                log.Debug($"订单新增数据 - 接口接收到数据:orderId:{m.OrderId},refno:{m.RefNo},SaleOrderCode:{m.SaleOrderCode},SysOrderCode:{m.SysOrderCode}");

                                var had = repository.Get(m.OrderId, x => x.Include(a => a.BnsSendDeliverdToEcs).Include(a => a.SalesOrderAddress).Include(a => a.OrderDetails));
                                if (had != null)
                                {
                                    List<BnsSendDeliverdToEc> templist = new List<BnsSendDeliverdToEc>();
                                    had.BnsSendDeliverdToEcs[0].ShippingMethodNo = m.ShippingMethodNo;
                                    had.BnsSendDeliverdToEcs[0].PlatformShipTime = m.PlatformShipTime;
                                    templist.Add(had.BnsSendDeliverdToEcs[0]);
                                    m.BnsSendDeliverdToEcs = templist;
                                    m.SalesOrderAddress.Id = had.SalesOrderAddress.Id;

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
                                    if (m.PlatformShipTime != null)
                                    {
                                        m.DeliverEmail = true;
                                    }
                                    insertList.Add(m);
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Debug($"订单新增数据 - 转换实体类出现异常:{ex.Message}");
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
                            log.Debug($"订单新增数据 - 写入数据库出现异常:{ex.Message}");
                            throw ex;
                        }
                    }
                    log.Info($"订单新增数据 - 拉取完成");
                    reqCondition.CreatedDateBefore = null;
                    reqCondition.CreatedDateAfter = null;
                    reqCondition.UpdateDateBefore = DateTime.Now;
                    reqCondition.UpdateDateAfter = updateTime;
                    reqModel.Page = 1;
                    reqModel.PageSize = 10;
                    req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    log.Info($"订单更新数据 - 开始获取 请求参数{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" })}");

                    response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    log.Info($"订单更新数据 - 开始获取 共计{pageNum}页");
                    for (int page = 1; page < pageNum + 1; page++)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;

                        try
                        {
                            log.Info($"订单更新数据 - 第{page}页;");
                            req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"订单更新数据 - 接口调用出现异常:{ex.Message}");
                            throw ex;
                        }
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);

                                var had = repository.Get(m.OrderId, x => x.Include(a => a.BnsSendDeliverdToEcs).Include(a => a.SalesOrderAddress).Include(a => a.OrderDetails));
                                if (had != null)
                                {
                                    log.Debug($"订单更新数据 - 接口接收到数据:orderId:{m.OrderId},refno:{m.RefNo},SaleOrderCode:{m.SaleOrderCode},SysOrderCode:{m.SysOrderCode}");
                                    List<BnsSendDeliverdToEc> templist = new List<BnsSendDeliverdToEc>();
                                    had.BnsSendDeliverdToEcs[0].ShippingMethodNo = m.ShippingMethodNo;
                                    had.BnsSendDeliverdToEcs[0].PlatformShipTime = m.PlatformShipTime;
                                    templist.Add(had.BnsSendDeliverdToEcs[0]);
                                    m.BnsSendDeliverdToEcs = templist;
                                    m.SalesOrderAddress.Id = had.SalesOrderAddress.Id;
                                    updateList.Add(m);
                                }
                                else
                                {
                                    log.Debug($"订单更新数据 - 还未插入表忽略,接口接收到数据:orderId:{m.OrderId},refno:{m.RefNo},SaleOrderCode:{m.SaleOrderCode},SysOrderCode:{m.SysOrderCode}");
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error($"订单更新数据 - 转换实体类出现异常:{ex.Message}");
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
                            log.Error($"订单更新数据 - 写入数据库异常:{ex.Message}");
                            throw ex;
                        }
                    }
                    log.Info("订单更新数据 - 拉取完成");
                }
            }
            catch (Exception ex)
            {
                log.Error($"订单更新数据 - 出现异常:{ex.Message}");
                throw ex;
            }
            log.Info($"订单数据 - 任务拉取完成");
        }
    }
}
