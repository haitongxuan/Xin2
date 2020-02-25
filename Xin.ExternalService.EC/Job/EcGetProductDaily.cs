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
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Job
{
    public class EcGetProductDaily : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcGetProductDaily(IUowProvider uowProvider)
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
            _uowProvider = uowProvider;
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
            reqModel.PageSize = 50;
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

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECProduct>();
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
                        addList.Add(Mapper<Response.Model.EC_Product, ECProduct>.Map(i));
                    }

                }
                //修改
            }
        }
    }
}
