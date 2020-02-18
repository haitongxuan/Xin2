using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Common;
using Xin.Repository;
using Xin.Service;
using Xin.WebApi.Model;
using Xin.Entities;
using System.Security.Claims;
using Xin.WebApi.Permission;
using Xin.Common.Model;

namespace LQExtension.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Permission")]
    public class PubPermissionController : Controller
    {
        private readonly IUowProvider _uowProvider;
        public PubPermissionController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }
        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="resourceId">资源名称</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetList/{resourceId}")]
        [PermissionFilter("Permission.Read")]
        public async Task<DataRes<List<ResPermission>>> GetList(int resourceId)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResPermission>();
                var data = await repository.GetAllAsync(x => x.OrderBy(p => p.Id),
                    x => x.Where(p => p.ResResource.Id == resourceId)).ConfigureAwait(false);

                return new DataRes<List<ResPermission>>() { data = data.ToList() };
            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        [PermissionFilter("Permission.Add")]
        public async Task<DataRes<bool>> AddAsync([FromBody]ResPermission model)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResPermission>();
                DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
                var sid = this.User.FindFirst(ClaimTypes.Sid);

                model.CreateDate = DateTime.Now;
                model.CreateUid = Convert.ToInt32(sid.Value);
                model.WriteUid = Convert.ToInt32(sid.Value);
                model.WriteDate = DateTime.Now;
                repository.Add(model);
                int i = await uow.SaveChangesAsync();
                if (i < 0)
                {
                    res.code = ResCode.Error;
                    res.data = false;
                    res.msg = "添加失败";
                }
                return res;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [Route("Edit")]
        [HttpPost]
        [PermissionFilter("Permission.Edit")]
        public async Task<DataRes<bool>> EditAsync([FromBody]ResPermission model)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            var sid = this.User.FindFirst(ClaimTypes.Sid);
            model.WriteDate = DateTime.Now;
            model.WriteUid = Convert.ToInt32(sid.Value);
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResPermission>();
                try
                {
                    model = repository.Update(model);
                    int i = await uow.SaveChangesAsync();
                    if (i < 0)
                    {
                        res.code = ResCode.Error;
                        res.data = false;
                        res.msg = "保存失败";
                    }
                }
                catch (Exception ex)
                {
                    res.code = ResCode.Error;
                    res.data = false;
                    res.msg = "保存失败," + ex.Message;
                }

                return res;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [PermissionFilter("Permission.Delete")]
        [HttpPost]
        public async Task<DataRes<bool>> DeleteAsync(string id)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResPermission>();
                var model = await repository.GetAsync(id);
                var sid = this.User.FindFirst(ClaimTypes.Sid);
                model.WriteDate = DateTime.Now;
                model.WriteUid = Convert.ToInt32(sid.Value);
                model.StopFlage = true;
                model = repository.Update(model);
                int i = await uow.SaveChangesAsync();
                if (i < 0)
                {
                    res.code = ResCode.Error;
                    res.data = false;
                    res.msg = "删除失败";
                }

                return res;
            }
        }
    }
}