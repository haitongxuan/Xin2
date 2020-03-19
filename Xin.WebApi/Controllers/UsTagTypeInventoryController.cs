using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Model;
using Xin.Web.Framework.Permission;
using Xin.Service;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsTagTypeInventoryController : BaseController<UsTagTypeInventory>
    {
        public UsTagTypeInventoryController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        [PermissionFilter("UsTagTypeInventory.Read")]
        [Route("GetPage")]
        [HttpPost]
        public ActionResult<DataRes<List<UsTagTypeInventory>>> GetPage(DatetimePointPageReq req)
        {
            var res = new DataRes<List<UsTagTypeInventory>>() { code = ResCode.Success };
            if (req != null)
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetCustomRepository<IUsTagTypeInventoryRepository>();
                    res.data = repository.GetPage(req.pageNum, req.pageSize, FilterNode.ListToString(req.query)).ToList();
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