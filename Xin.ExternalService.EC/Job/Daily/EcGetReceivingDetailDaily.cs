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
    public class EcGetReceivingDetailDaily : EcBaseJob
    {
        private readonly LogHelper log;
        public EcGetReceivingDetailDaily()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }
        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {

            List<ECReceivingDetail> updateList = new List<ECReceivingDetail>();
            List<ECReceivingDetail> insertList = new List<ECReceivingDetail>();

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ECReceivingDetail>();
                    DateTime lastGetTime = (DateTime)repository.GetPage(0, 1, x => x.OrderByDescending(c => c.AddTime)).FirstOrDefault().AddTime;
                    WMSGetReceivingDetailListReqModel reqModel = new WMSGetReceivingDetailListReqModel();
                    reqModel.DateFor = lastGetTime;
                    reqModel.DateTo = DateTime.Now;
                    reqModel.PageSize = 5;
                    reqModel.Page = 1;
                    WMSGetReceivingDetailListRequest req = new WMSGetReceivingDetailListRequest(login.Username, login.Password, reqModel);
                    log.Info($"入库单 - 开始拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
                    var response = await req.Request();
                    response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                    int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                    log.Info($"入库单 - 共计{pageNum}");
                    for (int page = 1; page < pageNum + 1; page++)
                    {
                        reqModel.PageSize = 1000;
                        reqModel.Page = page;
                        try
                        {
                            log.Info($"入库单 - 正在拉取{page}页");
                            req = new WMSGetReceivingDetailListRequest(login.Username, login.Password, reqModel);
                            response = await req.Request();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"入库单 - 接口调用出现异常:{ex.Message}");
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
                                log.Error($"入库单 - 转换实体类出现异常:{ex.Message}");
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
                            log.Error($"入库单 - 写入数据库异常 :{ex.Message}");
                            throw ex;
                        }
                    }
                    log.Info($"入库单 - 写入完成");
                }
                log.Info("入库单 - 任务完成");
            }
            catch (Exception ex)
            {
                log.Error($"入库单 - 出现异常 :{ex.Message}");
                throw;
            }
        }
    }
}
