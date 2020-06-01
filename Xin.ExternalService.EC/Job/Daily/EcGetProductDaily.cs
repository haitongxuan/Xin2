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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
            await Job();
        }

        public override async Task Job(DateTime? preTime = null)
        {
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
            var addList = new List<ECProduct>();
            var updateList = new List<ECProduct>();

            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork(false, false))
                {
                    var repository = uow.GetRepository<ECProduct>();
                    log.Info($"产品信息 - 开始拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
                    DateTime? lastAddTime = repository.QueryPage(0, 1, null, x => x.OrderByDescending(a => a.ProductAddTime)).FirstOrDefault().ProductAddTime;
                    DateTime? lastUpdateTime = repository.QueryPage(0, 1, null, x => x.OrderByDescending(a => a.ProductUpdateTime)).FirstOrDefault().ProductUpdateTime;

                    //新增
                    while (finish)
                    {
                        reqModel.Page = pageIndex;
                        reqModel.ProductAddTimeFrom = lastAddTime;
                        reqModel.ProductAddTimeTo = now;
                        log.Info($"产品信息 - 正在拉取第{pageIndex} 页");
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
                            log.Error($"产品信息 - 写入数据库出现异常:{ex.Message}");
                            throw ex;
                        }
                        pageIndex++;
                    }
                    log.Info("产品信息 - 拉取完成");

                    //修改
                    pageIndex = 1;
                    finish = true;
                    while (finish)
                    {
                        reqModel.Page = pageIndex;
                        reqModel.ProductAddTimeFrom = null;
                        reqModel.ProductAddTimeTo = null;
                        reqModel.ProductUpdateTimeFrom = lastUpdateTime;
                        reqModel.ProductUpdateTimeTo = now;
                        var req = new WMSGetProductListRequest(login.Username, login.Password, reqModel);
                        log.Info($"产品信息 - 开始更新拉取,请求参数:{JsonConvert.SerializeObject(reqModel, new IsoDateTimeConverter { DateTimeFormat = "yyyy - MM - dd HH: mm:ss" })}");
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
                            log.Error($"产品信息 - 写入数据库出现错误:{ex.Message}");
                            throw ex;
                        }
                        pageIndex++;
                    }
                    log.Info("产品信息 - 更新完成");

                }
                log.Info("产品信息 - 任务完成");
            }
            catch (Exception ex)
            {
                log.Error($"产品信息 - 出现错误:{ex.Message}");
                throw ex;
            }
        }
    }
}
