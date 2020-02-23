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
            await Job();
        }

        public override async Task Job()
        {
            var models = new List<ECProduct>();
            var reqModel = new Reqeust.Model.WMSGetProductListReqModel();
            reqModel.Page = 1;
            reqModel.PageSize = 50;
            reqModel.GetProductBox = IsOrNotEnum.是;
            reqModel.GetProductCombination = IsOrNotEnum.是;
            reqModel.GetProductCustomCategory = IsOrNotEnum.是;
            reqModel.GetProperty = IsOrNotEnum.是;
            reqModel.IsCombination = IsOrNotEnum.是;
            Reqeust.WMSGetProductListRequest req = new WMSGetProductListRequest(login.Username, login.Password, reqModel);
            var resp = await req.Request();
            foreach (var i in resp.Body)
            {
                var m = DataMapper.Mapper<ECProduct, EC_Product>(i);
                models.Add(m);
            }
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECProduct>();
                await repository.BulkInsertAsync(models, x => x.IncludeGraph = true);
                uow.BulkSaveChanges();
            }
        }
    }
}
