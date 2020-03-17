using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Repository;
using Xin.Entities;
using Xin.Service;
using Xin.Web.Framework.Model;
using System.Security.Claims;
using Xin.Web.Framework;
using Xin.Web.Framework.Permission;

namespace Xin.WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/ResDept")]
    public class ResDepartmentController : XinVDBaseController<ResDepartment>
    {
        public ResDepartmentController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        /// <summary>
        /// 获取子部门列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChildList/{id}")]
        [PermissionFilter("Dept.Read")]
        public DataRes<List<ResDepartment>> GetChildList(int id)
        {
            var result = new DataRes<List<ResDepartment>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResDepartment>();
                var depts = repository.Query(f => f.StopFlag == false && f.ParentId == id);
                result.data = depts.ToList();
            }

            return result;
        }


    }
}