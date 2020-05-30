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
using System.Linq;

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
            reqModel.PageSize = 10;
            reqModel.GetProductBox = IsOrNotEnum.Yes;
            reqModel.GetProductCombination = IsOrNotEnum.Yes;
            reqModel.GetProductCustomCategory = IsOrNotEnum.Yes;
            reqModel.GetProperty = IsOrNotEnum.Yes;
            reqModel.ProductAddTimeFrom = DateTime.Parse("2018-03-04");
            reqModel.ProductAddTimeTo = DateTime.Parse("2020/5/30 10:14:10");
            bool finish = true;
            int pageIndex = 1;
            var addList = new List<ECProduct>();

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECProduct>();
                //try
                //{
                //    await repository.DeleteAll();
                //    await uow.SaveChangesAsync();
                //}
                //catch (Exception ex)
                //{
                //    log.Error($"初始化产品信息,删除产品信息异常:{ex.Message}");
                //    throw ex;
                //}
                try
                {
                    while (finish)
                    {
                        reqModel.Page = pageIndex;
                        reqModel.PageSize = 1000;
                        var req = new WMSGetProductListRequest(login.Username, login.Password, reqModel);
                        var resp = await req.Request();
                        foreach (var i in resp.Body)
                        {
                            addList.Add(Mapper<Response.Model.EC_Product, ECProduct>.Map(i));
                        }
                        if (resp.Body.Count != 1000)
                        {
                            finish = false;
                        }
                        try
                        {
                            addList = addList.GroupBy(item => item.ProductSku).Select(item => item.First()).ToList();
                            await repository.BulkInsertAsync(addList, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            addList.Clear();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"产品信息,新增出现错误:{ex.Message}");

                            throw ex;
                        }
                        pageIndex++;
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
