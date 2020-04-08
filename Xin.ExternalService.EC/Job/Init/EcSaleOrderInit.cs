using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Common;
using Xin.Entities;
using Xin.Repository;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Job
{
    public class EcSaleOrderInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcSaleOrderInit(IUowProvider uowProvider)
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
            var models = new List<ECSalesOrder>();
            var reqModel = new EBGetOrderListReqModel();
            reqModel.Page = 1;
            reqModel.PageSize = 10;
            reqModel.GetDetail = IsOrNotEnum.Yes;
            reqModel.GetAddress = IsOrNotEnum.Yes;
            Conditions conditions = new Conditions();
            conditions.CreatedDateAfter = DateTime.Parse("2020-03-15");
            conditions.CreatedDateBefore = DateTime.Now;
            reqModel.Condition = conditions;

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECSalesOrder>();
                var addRepository = uow.GetRepository<ECSalesOrderAddress>();
                try
                {
                    await repository.DeleteAll();
                    await addRepository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"初始化产品信息,删除产品信息异常:{ex.Message}");
                    throw ex;
                }
                EBGetOrderListRequest req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                try
                {
                    var response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    for (int page = pageNum; page > 0; page--)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;
                        try
                        {
                            req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"订单信息,接口调用异常:时间区间{reqModel.Condition.CreatedDateAfter.ToString()}TO{reqModel.Condition.CreatedDateBefore.ToString()}第{page}页;异常信息:{ex.Message}");

                            throw ex;
                        }
                        foreach (var item in response.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(item);
                                List<BnsSendDeliverdToEc> templist = new List<BnsSendDeliverdToEc>();
                                BnsSendDeliverdToEc temp = new BnsSendDeliverdToEc();
                                temp.ShippingMethodNo = m.ShippingMethodNo;
                                temp.PlatformShipTime = m.PlatformShipTime;
                                templist.Add(temp);
                                m.BnsSendDeliverdToEcs = templist;
                                models.Add(m);
                            }
                            catch (Exception ex)
                            {
                                log.Error($"订单信息,接口调用异常:时间区间{reqModel.Condition.CreatedDateAfter.ToString()}TO{reqModel.Condition.CreatedDateBefore.ToString()}第{page}页;异常信息:{ex.Message}");
                                throw ex;
                            }
                        }

                        try
                        {
                            await repository.BulkInsertAsync(models, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            models.Clear();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"订单信息,写入数据库异常:时间区间{reqModel.Condition.CreatedDateAfter.ToString()}TO{reqModel.Condition.CreatedDateBefore.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {

                    log.Error("接口调用出现异常");
                }
            }
        }
    }
}
