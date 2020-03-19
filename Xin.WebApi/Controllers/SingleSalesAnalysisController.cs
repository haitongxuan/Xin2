using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Web.Framework.Controllers;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Service;
using Xin.Web.Framework.Permission;
using Xin.Web.Framework.Model;
using Microsoft.AspNetCore.Authorization;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SingleSalesAnalysisController : BaseController<SingleSalesAnalysis>
    {
        public SingleSalesAnalysisController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        [PermissionFilter("SingleSalesAnalysis.Read")]
        [Route("GetPage")]
        [HttpPost]
        public ActionResult<DataRes<List<SingleSalesAnalysis>>> GetPage(DatetimePointPageReq req)
        {
            var res = new DataRes<List<SingleSalesAnalysis>>() { code = ResCode.Success };
            if (req != null)
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetCustomRepository<ISingleSalesAnlysisRepository>();
                    res.data = repository.GetPage(req.datetimePoint, req.pageNum, req.pageSize, FilterNode.ListToString(req.query)).ToList();
                }
            else
            {
                res.code = ResCode.NoValidate;
                res.msg = ResMsg.ParameterIsNull;
            }
            return res;
        }
    }

}