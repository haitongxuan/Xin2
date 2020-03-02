using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Entities;
using Xin.Service;
using Xin.Repository;
using Xin.Web.Framework.Model;
using Xin.Common;
using Xin.WebApi;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Xin.Web.Framework.Helper;
using Xin.Web.Framework;

namespace LQExtension.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/ResRole")]
    [Authorize]
    public class ResRoleController : XinVDPageBaseController<ResRole>
    {
        private readonly IUowProvider _uowProvider;
        private readonly IDataPager<ResRole> _dataPager;

        public ResRoleController(IUowProvider uowProvider, IDataPager<ResRole> dataPager) : base(uowProvider, dataPager)
        {
            _uowProvider = uowProvider;
            _dataPager = dataPager;
        }

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <returns></returns>
        [Route("GetPermissions/{id}")]
        [HttpPost]
        public DataRes<IEnumerable<ResPermission>> GetPermissions(int id)
        {
            DataRes<IEnumerable<ResPermission>> res = new DataRes<IEnumerable<ResPermission>>() { code = ResCode.Success };
            List<ResPermission> list = new List<ResPermission>();
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResRole>();
                var role = repository.Get(id, x => x.Include(p => p.ResRolePermissions).
                ThenInclude(p => p.ResPermission));
                foreach (var rp in role.ResRolePermissions)
                {
                    list.Add(rp.ResPermission);
                }
                res.data = list;
            }


            return res;
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <returns></returns>
        [Route("SaveFunctions/{id}")]
        [HttpPost]
        public DataRes<bool> SavePermissions(int id, [FromBody]List<int> permissionIds)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };

            List<ResRolePermission> list = new List<ResRolePermission>();
            permissionIds.ForEach(p => { list.Add(new ResRolePermission() { RoleId = id, PermissionId = p }); });
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResRole>(); try
                {
                    var role = repository.Get(id, x => x.Include(p => p.ResRolePermissions));
                    role.ResRolePermissions = list;
                    repository.UpdateWithNavigationProperties(role);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    res.code = ResCode.Error;
                    res.data = false;
                    res.msg = "保存失败,失败原因:" + ex.Message;
                }

                return res;
            }
        }


    }

}