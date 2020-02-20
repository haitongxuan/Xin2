using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xin.Common;
using Xin.Repository;
using Xin.WebApi.Model;
using Xin.Entities;
using Xin.WebApi.Permission;
using Microsoft.EntityFrameworkCore;
using Xin.Common.Model;
using System;
using System.Linq;
using Xin.WebApi.Helper;

namespace Xin.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/User")]
    public class ResUserController : Controller
    {
        private readonly IUowProvider _uowProvider;
        private readonly IDataPager<ResUser> _dataPager;
        public ResUserController(IUowProvider uowProvider, IDataPager<ResUser> dataPager)
        {
            _uowProvider = uowProvider;
            _dataPager = dataPager;
        }

        /// <summary>
        /// 获取用户分页
        /// </summary>
        /// <returns></returns>
        [Route("GetPage")]
        [HttpPost]
        [PermissionFilter("User.Read")]
        public async Task<PageDateRes<ResUser>> GetPageAsync([FromBody]PageDataReq pageReq)
        {
            var page = new PageDateRes<ResUser>();
            var conHelper = new ConditionHeler<ResUser>("usergetpage");
            if (pageReq != null)
            {
                var query = pageReq.query;
                query.Add(new ConditionNode
                {
                    andorop = "and",
                    key = "StopFlag",
                    binaryop = "eq",
                    value = "true"
                });
                var fuc = conHelper.GetExpression(query);
                var filter = new Repository.Filter<ResUser>(fuc);
                var orderBy = new Repository.OrderBy<ResUser>(pageReq.order, false);
                try
                {
                    var result = await _dataPager.QueryAsync(pageReq.pageNum, pageReq.pageSize, filter,
                        orderBy,
                        p => p.Include(q => q.ResDepartment).Include(q => q.ResUserRoles).ThenInclude(q => q.ResRole));

                    page = PageMapper<ResUser>.ToPageDateRes(result);
                    return page;
                }
                catch (Exception ex)
                {
                    page.code = ResCode.Error;
                    page.msg = ex.Message;
                    return page;
                }
            }
            else
            {
                page.code = ResCode.Error;
                page.msg = "参数不正确";
                return page;
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        [PermissionFilter("User.Add")]
        public DataRes<bool> Add([FromBody]UserModel model)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                IEnumerable<ResUserPermission> upl = from pid in model.PermissionIds
                                                     select new ResUserPermission { PermissionId = pid };
                IEnumerable<ResUserRole> url = from rid in model.RoleIds
                                               select new ResUserRole { RoleId = rid };
                var repository = uow.GetRepository<ResUser>();
                try
                {
                    repository.Add(new ResUser
                    {
                        UserName = model.UserName,
                        UserPwd = model.UserPwd,
                        DeptId = model.DeptId,
                        Phone = model.Phone,
                        StopFlag = false,
                        Email = model.Email,
                        AdminFlag = model.AdminFlag,
                        HeadUrl = model.HeadUrl,
                        RealName = model.RealName,
                        ResUserPermissions = upl.ToList(),
                        ResUserRoles = url.ToList()
                    });
                    uow.SaveChangesAsync();
                    return new DataRes<bool>() { data = true };
                }
                catch (Exception ex)
                {
                    return new DataRes<bool>() { data = false, msg = ex.Message, code = ResCode.Error };
                }
            }
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <returns></returns>
        [Route("Edit")]
        [HttpPost]
        [PermissionFilter("User.Edit")]
        public DataRes<bool> Edit([FromBody]UserModel model)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                IEnumerable<ResUserPermission> upl = from pid in model.PermissionIds
                                                     select new ResUserPermission { PermissionId = pid };
                IEnumerable<ResUserRole> url = from rid in model.RoleIds
                                               select new ResUserRole { RoleId = rid };
                var repository = uow.GetRepository<ResUser>();
                var user = repository.Get(model.Id);
                try
                {
                    user.DeptId = model.DeptId;
                    user.Phone = model.Phone;
                    user.StopFlag = model.StopFlag;
                    user.Email = model.Email;
                    user.AdminFlag = model.AdminFlag;
                    user.HeadUrl = model.HeadUrl;
                    user.RealName = model.RealName;
                    user.ResUserPermissions = upl.ToList();
                    user.ResUserRoles = url.ToList();
                    user = repository.UpdateWithNavigationProperties(user);
                    uow.SaveChangesAsync();
                    return new DataRes<bool>() { data = true };
                }
                catch (Exception ex)
                {
                    return new DataRes<bool>() { data = false, msg = ex.Message, code = ResCode.Error };
                }
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpPost]
        [PermissionFilter("User.Delete")]
        public DataRes<bool> Delete(long id)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResUser>();
                var user = repository.Get(id);
                user.StopFlag = true;
                try
                {
                    user = repository.Update(user);
                    uow.SaveChangesAsync();
                    return new DataRes<bool>() { data = true };
                }
                catch (Exception ex)
                {
                    return new DataRes<bool>() { data = false, msg = ex.Message, code = ResCode.Error };
                }
            }
        }

        /// <summary>
        /// 获取用户的权限列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserPermissions")]
        [PermissionFilter("User.Edit")]
        public async Task<DataRes<List<ResPermission>>> GetUserPermissionsAsync(int userId)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var cr = uow.GetCustomRepository<Service.IResUserRepository>();
                var list = (await cr.GetAllPermissions(userId)).ToList();
                var dr = new DataRes<List<ResPermission>>() { data = list };
                return dr;
            }
        }
    }

}
