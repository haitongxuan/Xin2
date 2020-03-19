using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Entities;
using Xin.Repository;
using Xin.Service;
using Xin.ExternalService.EC.Reqeust;
using Xin.Common;
using System.Linq;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Job
{
    [DisallowConcurrentExecution]
    public class EcGetProductDaily : EcBaseJob
    {
        private readonly LogHelper log;
        public EcGetProductDaily()
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
        }
        public override async Task Execute(IJobExecutionContext context)
        {
            var preTime = context.Trigger.GetPreviousFireTimeUtc();
            if (preTime == null)
            {
                preTime = DateTime.Now.AddDays(-1);
            }
            await Job(preTime.Value.LocalDateTime);
        }

        public override async Task Job(DateTime? preTime = null)
        {
            if (preTime == null)
            {
                throw new Exception("返回为空！");
            }
            var models = new List<ECProduct>();
            var reqModel = new Reqeust.Model.WMSGetProductListReqModel();
            reqModel.PageSize = 1000;
            reqModel.GetProductBox = IsOrNotEnum.Yes;
            reqModel.GetProductCombination = IsOrNotEnum.Yes;
            reqModel.GetProductCustomCategory = IsOrNotEnum.Yes;
            reqModel.GetProperty = IsOrNotEnum.Yes;
            bool finish = true;
            int pageIndex = 1;
            DateTime now = DateTime.Now;
            DateTime lastTime = preTime.Value;
            var addList = new List<ECProduct>();
            var updateList = new List<ECProduct>();

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork(false, false))
                {
                    var repository = uow.GetRepository<ECProduct>();
                    RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetProductDaily", "INFO", $"产品信息新增,开始拉取", reqModel));

                    //新增
                    while (finish)
                    {
                        reqModel.Page = pageIndex;
                        reqModel.ProductAddTimeFrom = lastTime;
                        reqModel.ProductAddTimeTo = now;
                        var req = new WMSGetProductListRequest(login.Username, login.Password, reqModel);
                        var resp = await req.Request();
                        foreach (var i in resp.Body)
                        {
                            if (repository.Get(i.ProductSku) != null)
                            {
                                updateList.Add(Mapper<Response.Model.EC_Product, ECProduct>.Map(i));
                            }
                            else
                            {
                                addList.Add(Mapper<Response.Model.EC_Product, ECProduct>.Map(i));
                            }
                        }
                        if (resp.Body.Count != 1000)
                        {
                            finish = false;
                        }
                        try
                        {
                            updateList = updateList.GroupBy(item => item.ProductSku).Select(item => item.First()).ToList();
                            addList = addList.GroupBy(item => item.ProductSku).Select(item => item.First()).ToList();
                            await repository.BulkUpdateAsync(updateList);
                            await repository.BulkInsertAsync(addList);
                            uow.BulkSaveChanges();
                            addList.Clear();
                            updateList.Clear();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"日产品信息,新增出现错误:{ex.Message}");

                            throw ex;
                        }
                        pageIndex++;
                    }
                    //修改
                    pageIndex = 1;
                    finish = true;
                    RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetProductDaily", "INFO", $"产品信息更新,开始拉取", reqModel));
                    while (finish)
                    {
                        reqModel.Page = pageIndex;
                        reqModel.ProductAddTimeFrom = null;
                        reqModel.ProductAddTimeTo = null;
                        reqModel.ProductUpdateTimeFrom = preTime;
                        reqModel.ProductUpdateTimeTo = now;
                        var req = new WMSGetProductListRequest(login.Username, login.Password, reqModel);
                        var resp = await req.Request();
                        foreach (var i in resp.Body)
                        {
                            updateList.Add(Mapper<Response.Model.EC_Product, ECProduct>.Map(i));
                        }
                        if (resp.Body.Count != 1000)
                        {
                            finish = false;
                        }
                        try
                        {
                            updateList = updateList.GroupBy(item => item.ProductSku).Select(item => item.First()).ToList();
                            addList = addList.GroupBy(item => item.ProductSku).Select(item => item.First()).ToList();
                            await repository.BulkUpdateAsync(updateList);
                            await repository.BulkInsertAsync(addList);
                            uow.BulkSaveChanges();
                            addList.Clear();
                            updateList.Clear();
                        }
                        catch (Exception ex)
                        {
                            RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetProductDaily", "ERROR", $"产品信息更新,写入数据库出现异常:{ex.Message}", reqModel));
                            log.Error($"日产品信息,更新出现错误:{ex.Message}");
                            throw ex;
                        }
                        pageIndex++;
                    }
                }
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetProductDaily", "INFO", $"产品信息,拉取完成", reqModel));

            }
            catch (Exception ex)
            {
                RabbitMqUtils.pushMessage(new LogPushModel("XIN", "EcGetProductDaily", "ERROR", $"产品信息,出现异常:{ex.Message}", reqModel));

                log.Error($"日产品信息,出现错误:{ex.Message}");

                throw ex;
            }
        }
    }
}
