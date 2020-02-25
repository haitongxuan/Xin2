using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Common;
using Xin.Entities;
using Xin.Repository;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Job
{
    public class EcSaleOrderInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcSaleOrderInit(IUowProvider uowProvider)
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
            var models = new List<ECSalesOrder>();
            var reqModel = new Reqeust.Model.EBGetOrderListReqModel();
            reqModel.PageSize = 50;
            bool finish = true;
            int pageIndex = 1;

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECSalesOrder>();
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
                    Reqeust.EBGetOrderListRequest req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    Response.EBGetOrderListResponse resp = null;
                    try
                    {
                        resp = await req.Request();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"初始化产品信息,获取数据错误:{ex.Message}");
                        throw ex;
                    }
                    if (resp.Body.Count == 50)
                    {
                        foreach (var i in resp.Body)
                        {
                            var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(i);
                            models.Add(m);
                        }
                        if (pageIndex % 20 == 0)
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
                        finish = false;
                    }
                }

            }
        }
    }
}
