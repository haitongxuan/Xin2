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
using Xin.ExternalService.EC.Response.Model;
using Xin.ExternalService.EC.Reqeust.Model;
using Z.BulkOperations;


namespace Xin.ExternalService.EC.Job
{
    public class EcGetProductInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcGetProductInit(IUowProvider uowProvider)
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
            var models = new List<ECProduct>();
            var reqModel = new Reqeust.Model.WMSGetProductListReqModel();
            reqModel.PageSize = 500;
            reqModel.GetProductBox = IsOrNotEnum.Yes;
            reqModel.GetProductCombination = IsOrNotEnum.Yes;
            reqModel.GetProductCustomCategory = IsOrNotEnum.Yes;
            reqModel.IsCombination = IsOrNotEnum.Yes;
            reqModel.GetProperty = IsOrNotEnum.Yes;
            int submitPageQty = 10;
            bool finish = true;
            int pageIndex = 1;

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECProduct>();
                try
                {
                    await repository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"初始化产品信息,删除产品信息异常:{ex.Message}");
                    throw ex;
                }
                while (finish)
                {
                    reqModel.Page = pageIndex;
                    Reqeust.WMSGetProductListRequest req = new WMSGetProductListRequest(login.Username, login.Password, reqModel);
                    Response.WMSGetProductListResponse resp = null;
                    try
                    {
                        resp = await req.Request();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"初始化产品信息,获取数据错误:{ex.Message}");
                        throw ex;
                    }
                    if (resp.Body.Count == reqModel.PageSize)
                    {
                        foreach (var i in resp.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_Product, ECProduct>.Map(i);
                                models.Add(m);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        if (pageIndex % submitPageQty == 0)
                        {
                            try
                            {
                                await repository.BulkInsertAsync(models, x => x.IncludeGraph = true);
                                uow.BulkSaveChanges();
                                models.Clear();
                            }
                            catch (Exception ex)
                            {
                                log.Error($"初始化产品信息,批量导入产品异常:第{pageIndex}页,{ex.Message}");
                                throw ex;
                            }
                        }
                        pageIndex++;
                    }
                    else
                    {
                        try
                        {
                            foreach (var i in resp.Body)
                            {
                                try
                                {
                                    var m = Mapper<EC_Product, ECProduct>.Map(i);
                                    models.Add(m);
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                            await repository.BulkInsertAsync(models, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            models.Clear();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"初始化产品信息,批量导入产品异常:第{pageIndex}页,{ex.Message}");
                            throw ex;
                        }
                        finish = false;
                    }
                }

            }
        }
    }
}
