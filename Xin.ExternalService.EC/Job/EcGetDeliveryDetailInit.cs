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
    public class EcGetDeliveryDetailInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcGetDeliveryDetailInit(IUowProvider uowProvider)
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
            WMSGetDeliveryDetailListReqModel reqModel = new WMSGetDeliveryDetailListReqModel();
            reqModel.DateFor = DateTime.Parse("2018-01-01");
            reqModel.DateTo = DateTime.Now;
            reqModel.PageSize = 5;
            reqModel.Page = 1;
            List<ECDeliveryDetail> deliveryDetails = new List<ECDeliveryDetail>();

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECDeliveryDetail>();
                try
                {
                    await repository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"初始化入库单信息,删除入库单信息异常:{ex.Message}");
                    throw ex;
                }
                WMSGetDeliveryDetailListRequest req = new WMSGetDeliveryDetailListRequest(login.Username, login.Password, reqModel);
                var response = await req.Request();
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);

                for (int page = pageNum; page > 0; page--)
                {
                    reqModel.PageSize = 1000;
                    reqModel.Page = page;
                    try
                    {
                        req = new WMSGetDeliveryDetailListRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    foreach (var item in response.Body)
                    {
                        try
                        {
                            var m = Mapper<EC_DeliveryDetail, ECDeliveryDetail>.Map(item);
                            deliveryDetails.Add(m);
                        }
                        catch (Exception ex)
                        {
                            log.Error($"转换实体类出现异常:时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }

                    try
                    {
                        await repository.BulkInsertAsync(deliveryDetails, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        deliveryDetails.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"入库单信息,写入数据库异常:时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                }
                log.Info($"入库单信息拉取写入完成,时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}");
            }
        }
    }
}
