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

namespace Xin.ExternalService.EC.Job.Init
{
    public class EcTransitBatchNumberInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcTransitBatchNumberInit(IUowProvider uowProvider)
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
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECTransitBatchNumber>();
                await repository.DeleteAll();
                await uow.SaveChangesAsync();
                WMSGetTransitBatchNumberReqModel reqModel = new WMSGetTransitBatchNumberReqModel();
                reqModel.Page = 1;
                reqModel.PageSize = 10;
                WMSTransitBatchNumberRequest req = new WMSTransitBatchNumberRequest(login.Username, login.Password, reqModel);
                log.Info($"批次入库在途 - 开始拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
                var response = await req.Request();
                response.TotalCount = response.TotalCount == null ? "1" : response.TotalCount;
                int pageNum = (int)Math.Ceiling(long.Parse(response.TotalCount) * 1.0 / 1000);
                List<ECTransitBatchNumber> insertList = new List<ECTransitBatchNumber>();
                log.Info($"批次入库在途 - 共计{pageNum}页");
                for (int page = 1; page < pageNum + 1; page++)
                {
                    reqModel.Page = page;
                    reqModel.PageSize = 1000;
                    log.Info($"批次入库在途 - 正在拉取{page}页");
                    req = new WMSTransitBatchNumberRequest(login.Username, login.Password, reqModel);
                    response = await req.Request();
                    foreach (var item in response.Body)
                    {
                        var m = Mapper<EC_TransitBatchNumber, ECTransitBatchNumber>.Map(item);
                        insertList.Add(m);
                    }

                    try
                    {
                        insertList = insertList.GroupBy(item => new { item.RoCode, item.ProductSku }).Select(item => item.First()).ToList();
                        await repository.BulkInsertAsync(insertList, x => x.IncludeGraph = true);
                        uow.BulkSaveChanges();
                        insertList.Clear();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"批次入库在途 - 出现异常:{ex.Message}");
                        throw;
                    }
                }
            }
            log.Info($"批次入库在途 - 拉取完成");
        }
    }
}
