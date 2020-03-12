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
    public class EcGetReceivingDetailDaily : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcGetReceivingDetailDaily(IUowProvider uowProvider)
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
            
            List<ECReceivingDetail> updateList = new List<ECReceivingDetail>();
            List<ECReceivingDetail> insertList = new List<ECReceivingDetail>();

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECReceivingDetail>();
                DateTime lastGetTime = (DateTime)repository.GetPage(0, 1, x => x.OrderByDescending(c => c.AddTime)).FirstOrDefault().AddTime;
                WMSGetReceivingDetailListReqModel reqModel = new WMSGetReceivingDetailListReqModel();
                reqModel.DateFor =lastGetTime;
                reqModel.DateTo = DateTime.Now;
                reqModel.PageSize = 5;
                reqModel.Page = 1;
                WMSGetReceivingDetailListRequest req = new WMSGetReceivingDetailListRequest(login.Username, login.Password, reqModel);
                var response = await req.Request();
                response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                for (int page = pageNum; page > 0; page--)
                {
                    reqModel.PageSize = 1000;
                    reqModel.Page = page;
                    try
                    {
                        log.Info($"入库信息,开始拉取:时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}第{page}页;");
                        req = new WMSGetReceivingDetailListRequest(login.Username, login.Password, reqModel);
                        response = await req.Request();
                    }
                    catch (Exception ex) 
                    {
                        log.Error($"入库信息,接口调用出现异常:时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                    foreach (var item in response.Body)
                    {
                        try
                        {
                            var m = Mapper<EC_ReceivingDetail, ECReceivingDetail>.Map(item);
                            var res = repository.Get(item.RlId);
                            if (res != null)
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
                            log.Error($"入库信息,转换实体类出现异常:时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                            throw ex;
                        }
                    }

                    try
                    {
                        insertList = insertList.GroupBy(item => item.RlId).Select(item => item.First()).ToList();
                        updateList = updateList.GroupBy(item => item.RlId).Select(item => item.First()).ToList();
                        await repository.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                        await repository.BulkUpdateAsync(updateList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        insertList.Clear();
                        updateList.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"入库信息,写入数据库异常:时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}第{page}页;异常信息:{ex.Message}");
                        throw ex;
                    }
                }
                log.Info($"入库信息拉取写入完成,时间区间{reqModel.DateFor.ToString()}TO{reqModel.DateTo.ToString()}");

            }
        }
    }
}
