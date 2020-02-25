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
using Xin.Common.Model;
using Xin.Common;
using Xin.WebApi;
using Xin.WebApi.Helper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LQExtension.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/ResRole")]
    [Authorize]
    public class ResRoleController : Controller
    {
        private readonly IUowProvider _uowProvider;
        private readonly IDataPager<ResRole> _dataPager;

        public ResRoleController(IUowProvider uowProvider, IDataPager<ResRole> dataPager)
        {
            _uowProvider = uowProvider;
            _dataPager = dataPager;
        }

        [Route("GetList")]
        [HttpPost]
        public async Task<DataRes<List<ResRole>>> GetList()
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var roles = await uow.GetRepository<ResRole>().GetAllAsync();

                return new DataRes<List<ResRole>> { data = roles.ToList() };
            }
        }

        /// <summary>
        /// 获取角色分页
        /// </summary>
        /// <returns></returns>
        [Route("GetPage")]
        [HttpPost]
        public async Task<PageDateRes<ResRole>> GetPage([FromBody]PageDataReq pageReq)
        {
            var page = new PageDateRes<ResRole>();
            var conHelper = new ConditionHeler<ResRole>("rolegetpage");
            if (pageReq != null)
            {
                var query = pageReq.query;
                var fuc = conHelper.GetExpression(query);
                var filter = new Filter<ResRole>(fuc);
                var orderBy = new OrderBy<ResRole>(pageReq.order, false);
                try
                {
                    var result = await _dataPager.QueryAsync(pageReq.pageNum, pageReq.pageSize, filter,
                        orderBy);

                    page = PageMapper<ResRole>.ToPageDateRes(result);
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
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public DataRes<bool> Add([FromBody]ResRole model)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResRole>();
                try
                {
                    repository.Add(model);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    res.code = ResCode.Error;
                    res.data = false;
                    res.msg = "数据保存失败,失败原因:" + ex.Message;
                }
            }

            return res;
        }

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <returns></returns>
        [Route("Edit")]
        [HttpPost]
        public DataRes<bool> Edit([FromBody]ResRole model)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };

            model.WriteDate = DateTime.Now;
            model.WriteUid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResRole>();
                try
                {
                    model = repository.Update(model);
                    uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    res.code = ResCode.Error;
                    res.data = false;
                    res.msg = "保存失败,失败原因:" + ex.Message;
                }
            }

            return res;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpPost]
        public DataRes<bool> Delete(long id)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResRole>();
                var model = repository.Get(id);
                try
                {
                    repository.Remove(model);
                }
                catch (Exception ex)
                {
                    res.code = ResCode.Error;
                    res.data = false;
                    res.msg = "删除失败,失败原因:" + ex.Message;
                }


                return res;
            }
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