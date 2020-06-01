using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
                log.Info($"退货订单 - 开始拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
                var response = await req.Request();
                response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                List<ECRMARefund> rmaRefunds = new List<ECRMARefund>();
                log.Info($"退货订单 - 共计{pageNum}页");
                for (int page = 1; page < pageNum + 1; page++)
                {
                    reqModel.PageSize = 1000;
                    reqModel.Page = page;
                    try
                    {
                        log.Info($"退货订单 - 正在拉取第{page}页");
                        req = new EBGetRmaRefundListRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"退货订单 - 接口调用出现异常:{ex.Message}");
                        throw ex;
                    }
                    foreach (var item in response.Body)
                    {
                        try
                        {
                            var m = Mapper<EC_RmaRefund, ECRMARefund>.Map(item);
                            if (repository.Query(a => a.RefNo == m.RefNo && a.ProductSku == m.ProductSku).FirstOrDefault() == null)
                            {
                                rmaRefunds.Add(m);
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error($"退货订单 - 转换实体类出现异常:{ex.Message}");
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
                        log.Error($"退货订单 - 写入数据库异常:{ex.Message}");
                        throw ex;
                    }
                }
                //更新
                log.Info($"退货订单 - 拉取完成");
            }
            log.Info($"退货订单 - 任务拉取完成");

        }
    }
}
