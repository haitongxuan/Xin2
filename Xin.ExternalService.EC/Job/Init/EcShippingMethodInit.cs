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
    public class EcShippingMethodInit : EcBaseJob
    {
        private readonly LogHelper log;
        public EcShippingMethodInit()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }
        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {
            List<ECShippingMethod> insertList = new List<ECShippingMethod>();
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcShippingMethodInit", "INFO", "开始拉取数据", null));

                var repository = uow.GetRepository<ECShippingMethod>();
                try
                {
                    await repository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"物流承运拉取出现异常,清空出现异常:{ex.Message}");
                    throw ex;
                }

                try
                {
                    WMSGetShippingMethodRequest req = new WMSGetShippingMethodRequest(login.Username, login.Password);
                    var response = await req.Request();
                    foreach (var item in response.Body)
                    {
                        var m = Mapper<EC_ShippingMethod, ECShippingMethod>.Map(item);
                        insertList.Add(m);
                    }
                    repository.BulkInsert(insertList, x => x.IncludeGraph = true);
                    uow.SaveChanges();
                    log.Info("物流承运拉取完成");
                    RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcShippingMethodInit", "INFO", "物流承运拉取完成", null));

                }
                catch (Exception ex)
                {
                    log.Error($"物流承运拉取出现异常:{ex.Message}");
                    RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcShippingMethodInit", "ERROOR", $"物流承运拉取出现异常:{ex.Message}", null));
                    throw;
                }
            }
        }
    }
}
