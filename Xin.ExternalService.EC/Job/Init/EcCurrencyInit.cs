using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Common;
using Xin.Entities;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Job.Init
{
    public class EcCurrencyInit : EcBaseJob
    {
        private readonly LogHelper log;
        public EcCurrencyInit()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }
        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {
            List<ECCurrency> insertList = new List<ECCurrency>();
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECCurrency>();
                try
                {
                    await repository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"货币对应 - 出现异常{ex.Message}");
                    throw ex;
                }

                try
                {
                    WMSGetCurrencyRequest req = new WMSGetCurrencyRequest(login.Username, login.Password);
                    log.Info($"货币对应 - 开始拉取");
                    var response = await req.Request();
                    foreach (var item in response.Body)
                    {
                        var m = Mapper<EC_Currency, ECCurrency>.Map(item);
                        insertList.Add(m);
                    }
                    repository.BulkInsert(insertList, x => x.IncludeGraph = true);
                    uow.SaveChanges();
                    log.Info($"货币对应 - 拉取完成");
                }
                catch (Exception ex )
                {
                    log.Error($"货币对应 - 出现异常:{ex.Message}");
                    throw;
                }
            }
        }
    }
}
