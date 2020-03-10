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
    public class EcGetRmaRefundInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcGetRmaRefundInit(IUowProvider uowProvider)
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
            EBGetRmaRefundListReqModel reqModel = new EBGetRmaRefundListReqModel();
            reqModel.Page = 1;
            reqModel.PageSize = 50;
            reqModel.CreateDateForm = DateTime.Parse("2018-01-01");
            reqModel.CreateDateTo = DateTime.Now;
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECRMARefund>();
                try
                {
                    await repository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"初始化退货信息信息,删除退货信息信息异常:{ex.Message}");
                    throw ex;
                }
                EBGetRmaRefundListRequest req = new EBGetRmaRefundListRequest(login.Username, login.Password, reqModel);
                var response = await req.Request();
                response.TotalCount = response.TotalCount ==null ? "1" : response.TotalCount;
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);

                List<ECRMARefund> rmaRefunds = new List<ECRMARefund>();
                for (int page = pageNum; page > 0; page--)
                {
                    reqModel.PageSize = 1000;
                    reqModel.Page = page;
                    try
                    {
                        log.Info($"退货信息,开始拉取:时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}第{page}页;");
                        req = new EBGetRmaRefundListRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"退货信息,接口调用出现异常:时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                    foreach (var item in response.Body)
                    {
                        try
                        {
                            var m = Mapper<EC_RmaRefund, ECRMARefund>.Map(item);
                            rmaRefunds.Add(m);
                        }
                        catch (Exception ex)
                        {
                            log.Error($"退货信息,转换实体类出现异常:时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }

                    try
                    {
                        await repository.BulkInsertAsync(rmaRefunds, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        rmaRefunds.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"退货信息,写入数据库异常:时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                }
                log.Info($"退货信息拉取写入完成,时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}");
            }
        }
    }
}
