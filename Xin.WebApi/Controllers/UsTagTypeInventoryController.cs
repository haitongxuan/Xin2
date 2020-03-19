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
using Xin.Web.Framework.Helper;

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
        public ActionResult<PageDataRes<UsTagTypeInventory>> GetPage(PageReq req)
        {
            var res = new PageDataRes<UsTagTypeInventory>() { code = ResCode.Success };
            if (req != null)
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetCustomRepository<IUsTagTypeInventoryRepository>();
                    var page = repository.GetPage(req.pageNum, req.pageSize, FilterNode.ListToString(req.query));
                    res = PageMapper<UsTagTypeInventory>.ToPageDateRes(page);
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