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

namespace Xin.ExternalService.EC.Job
{
    [DisallowConcurrentExecution]
    public class EcGetRmaRefundDaily : EcBaseJob
    {
        private readonly LogHelper log;
        public EcGetRmaRefundDaily()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECRMARefund>();
                //新创建
                EBGetRmaRefundListReqModel reqModel = new EBGetRmaRefundListReqModel();
                reqModel.Page = 1;
                reqModel.PageSize = 50;
                reqModel.CreateDateForm = DateTime.Parse(repository.GetPage(0, 1, x => x.OrderByDescending(c => c.CreateDate)).FirstOrDefault().CreateDate);
                reqModel.CreateDateTo = DateTime.Now;
                EBGetRmaRefundListRequest req = new EBGetRmaRefundListRequest(login.Username, login.Password, reqModel);
                var response = await req.Request();
                response.TotalCount = response.TotalCount ==null ? "1" : response.TotalCount;
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                List<ECRMARefund> rmaRefunds = new List<ECRMARefund>();
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetRmaRefundDaily", "INFO", $"开始拉取退货信息数据,共{pageNum}页", reqModel));
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
                        RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetRmaRefundDaily", "ERROR", $"拉取退货信息数据异常:{ex.Message},第{page}页", reqModel));
                        log.Error($"退货信息,接口调用出现异常:时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                    foreach (var item in response.Body)
                    {
                        try
                        {
                            var m = Mapper<EC_RmaRefund, ECRMARefund>.Map(item);
                            if (repository.Query(a=>a.RefNo == m.RefNo &&a.ProductSku == m.ProductSku).FirstOrDefault()==null)
                            {
                                rmaRefunds.Add(m);
                            }
                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetRmaRefundDaily", "ERROR", $"拉取退货信息转换实体类出现异常:{ex.Message},第{page}页", reqModel));

                            log.Error($"退货信息,转换实体类出现异常:时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }

                    try
                    {
                        rmaRefunds = rmaRefunds.GroupBy(item => new { item.RefNo, item.ProductSku }).Select(item => item.First()).ToList();
                        await repository.BulkInsertAsync(rmaRefunds, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        rmaRefunds.Clear();
                    }
                    catch (Exception ex)
                    {
                        RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetRmaRefundDaily", "ERROR", $"拉取退货信息写入数据库异常:{ex.Message},第{page}页", reqModel));

                        log.Error($"退货信息,写入数据库异常:时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                }
                //更新
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetRmaRefundDaily", "INFO", $"拉取退货信息写入数据库完成", null));
                log.Info($"退货信息拉取写入完成,时间区间{reqModel.CreateDateForm.ToString()}TO{reqModel.CreateDateTo.ToString()}");
            }
        }
    }
}
