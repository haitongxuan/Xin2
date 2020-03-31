using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xin.Entities;
using Xin.Repository;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Helper;
using Xin.Web.Framework.Model;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResMenusController : BaseController<ResMenu>
    {
        public ResMenusController(IUowProvider uowProvider) : base(uowProvider)
        {
        }
        [Route("GetMenus")]
        [HttpGet]
        public DataRes<List<ResMenuResponse>> GetMenus()
        {
            var res = new GridPage<List<ResMenuResponse>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ResMenu>();
                    var repoResult = repository.GetAll().ToList();
                    var result = TreeHelper.ToTreeResponse(repoResult);
                    var finallResult = TreeHelper.ToTree(result);
                    res.data = finallResult;
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }
        [Route("AddMenus")]
        [HttpPost]
        public DataRes<List<ResMenuResponse>> AddMenus([FromBody] ResMenu  menu,int? parentId )
        {
            var res = new GridPage<List<ResMenuResponse>>() { code = ResCode.Success };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ResMenu>();
                    if (parentId!=null&&parentId!=0)
                    {
                        menu.Parent = repository.Get(1);
                    }
                    repository.Add(menu);
                    uow.SaveChanges();
                    res.data = null;
                    res.msg = "添加成功";
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }


    }
}