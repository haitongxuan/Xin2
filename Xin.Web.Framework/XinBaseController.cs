using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xin.Common;
using Xin.Web.Framework.Model;
using Xin.Repository;
using Xin.Web.Framework.Helper;
using Xin.Web.Framework.Permission;
using Xin.Entities;
using Xin.Service;

namespace Xin.Web.Framework
{
    [Authorize]
    [Produces("application/json")]
    public abstract class XinBaseController<TEntity> : Controller where TEntity : Entities.XinBaseEntity, new()
    {
        protected readonly IUowProvider _uowProvider;
        protected readonly string _typeName;
        public XinBaseController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
            _typeName = typeof(TEntity).FullName;
        }

        protected int UserId => Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Sid)).Value);
        protected async Task<string> GetPermissionCode(IUnitOfWork uow, string tag)
        {
            var repository = uow.GetRepository<ResResource>();
            var resource = (await repository.QueryAsync(x => x.TypeName == _typeName)).FirstOrDefault();
            string permissionCode = $"{resource.ResourceCode}.{tag}";
            return permissionCode;

        }

        protected async Task<bool> CheckPermission(string permissionCode, IUnitOfWork uow)
        {
            if (User.IsInRole("Admin"))
            {
                return true;
            }
            else
            {
                permissionCode = await GetPermissionCode(uow, permissionCode);
                var cRepository = uow.GetCustomRepository<IResUserRepository>();
                var userIdClaim = User.FindFirst(p => p.Type == ClaimTypes.Name);
                return await cRepository.CheckPermission(userIdClaim.Value, permissionCode);
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetList")]
        public virtual async Task<ActionResult<DataRes<List<TEntity>>>> GetList(BaseReq req)
        {
            var result = new DataRes<List<TEntity>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                bool cp = await CheckPermission("Read", uow);

                if (cp)
                {
                    try
                    {
                        OrderBy<TEntity> order = null;
                        if (req.order != null)
                        {
                            order = new OrderBy<TEntity>(req.order.columnName, req.order.reverse);
                        }
                        var repository = uow.GetRepository<TEntity>();
                        var models = await repository.NGetAllAsync(order.Expression, req.navPropertyPaths);
                        result.data = models.ToList();

                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.code = ResCode.ServerError;
                        result.msg = $"{ex.Message}:{ex.InnerException.Message}";
                        return result;
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
        }
        /// <summary>
        /// 获取模型对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Get")]
        [HttpPost]
        public virtual async Task<ActionResult<DataRes<TEntity>>> Get([FromBody] IdentityReq req)
        {
            DataRes<TEntity> res = new DataRes<TEntity>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                bool cp = await CheckPermission("Read", uow);
                if (cp)
                {
                    try
                    {
                        var repository = uow.GetRepository<TEntity>();
                        OrderBy<TEntity> order = null;
                        if (req.order != null)
                        {
                            order = new OrderBy<TEntity>(req.order.columnName, req.order.reverse);
                        }
                        var models = await repository.GetAsync(req.id, order, req.navPropertyPaths);
                        res.data = models;
                        return res;
                    }
                    catch (Exception ex)
                    {
                        res.code = ResCode.ServerError;
                        res.msg = $"{ex.Message}:{ex.InnerException.Message}";
                        return res;
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public virtual async Task<ActionResult<DataRes<bool>>> Add([FromBody]TEntity model)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                bool cp = await CheckPermission("Add", uow);
                if (cp)
                {
                    try
                    {
                        var repository = uow.GetCustomRepository<IXinRepository<TEntity>>();
                        string us = User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Sid)).Value;
                        if (us != null)
                        {
                            int userid = Convert.ToInt32(us);
                            model.CreateUid = userid;
                            model.WriteUid = userid;
                            model.CreateDate = DateTime.Now;
                            model.WriteDate = DateTime.Now;
                            repository.Add(model);
                            uow.SaveChanges();
                        }

                        else
                        {
                            res.code = ResCode.Error;
                            res.data = false;
                            res.msg = "当前登录用户信息获取失败";
                        }
                        return res;
                    }
                    catch (Exception ex)
                    {
                        res.code = ResCode.ServerError;
                        res.data = false;
                        res.msg = $"{ex.Message}:{ex.InnerException.Message}";
                        return res;
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [Route("Edit")]
        [HttpPost]
        public virtual async Task<ActionResult<DataRes<bool>>> Edit([FromBody]TEntity model)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                bool cp = await CheckPermission("Edit", uow);
                if (cp)
                {
                    try
                    {
                        var repository = uow.GetRepository<TEntity>();
                        string us = User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Sid)).Value;
                        if (us != null)
                        {
                            int userid = Convert.ToInt32(us);
                            model.WriteUid = userid;
                            model.WriteDate = DateTime.Now;
                            repository.Update(model);
                            uow.SaveChanges();
                        }
                        else
                        {
                            res.code = ResCode.Error;
                            res.data = false;
                            res.msg = "当前登录用户信息获取失败";
                        }
                        return res;
                    }
                    catch (Exception ex)
                    {
                        res.code = ResCode.ServerError;
                        res.msg = $"{ex.Message}:{ex.InnerException.Message}";
                        return res;
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpPost]
        public virtual async Task<ActionResult<DataRes<bool>>> Delete(string id)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                bool cp = await CheckPermission("Delete", uow);
                if (cp)
                {
                    try
                    {
                        var repository = uow.GetRepository<TEntity>();
                        var model = repository.Get(id);
                        string us = User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Sid)).Value;
                        if (us != null)
                        {
                            int userid = Convert.ToInt32(us);
                            repository.Remove(model);
                            uow.SaveChanges();
                        }
                        else
                        {
                            res.code = ResCode.Error;
                            res.data = false;
                            res.msg = "当前登录用户信息获取失败";
                        }
                        return res;
                    }
                    catch (Exception ex)
                    {
                        res.code = ResCode.ServerError;
                        res.msg = $"{ex.Message}:{ex.InnerException.Message}";
                        return res;
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
        }

    }

    public abstract class XinPageBaseController<TEntity> : XinBaseController<TEntity> where TEntity : Entities.XinBaseEntity, new()
    {
        protected readonly IDataPager<TEntity> _dataPager;
        public XinPageBaseController(IUowProvider uowProvider, IDataPager<TEntity> dataPager) : base(uowProvider)
        {
            _dataPager = dataPager;
        }

        /// <summary>
        /// 获取用户分页
        /// </summary>
        /// <returns></returns>
        [Route("GetPage")]
        [HttpPost]
        public virtual async Task<ActionResult<PageDateRes<TEntity>>> GetPageAsync([FromBody]PageDataReq pageReq)
        {
            bool cp = false;
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                cp = await CheckPermission("Read", uow);
            }
            string nvastr = "";
            string parameterstr = typeof(TEntity).Name + "Page";
            if (cp)
            {
                var page = new PageDateRes<TEntity>();
                try
                {
                    if (pageReq != null)
                    {
                        var query = pageReq.query;
                        var fuc = FilterHelper<TEntity>.GetExpression(query, parameterstr);
                        var filter = new Repository.Filter<TEntity>(fuc);
                        if (string.IsNullOrEmpty(pageReq.order.columnName))
                        {
                            pageReq.order.columnName = "Id";
                            pageReq.order.reverse = false;
                        }
                        var orderBy = new Repository.OrderBy<TEntity>(pageReq.order.columnName, pageReq.order.reverse);
                        var includes = _uowProvider.CreateUnitOfWork().GetRepository<TEntity>();

                        try
                        {
                            var result = await _dataPager.QueryAsync(pageReq.pageNum, pageReq.pageSize, filter,
                                orderBy, pageReq.navPropertyPaths);

                            page = PageMapper<TEntity>.ToPageDateRes(result);
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
                        page.msg = "参数不能为空";
                        return page;
                    }
                }
                catch (Exception ex)
                {
                    page.code = ResCode.ServerError;
                    page.msg = $"{ex.Message}:{ex.InnerException.Message}";
                    return page;
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }

    public abstract class XinVDBaseController<TEntity> : XinBaseController<TEntity> where TEntity : Entities.XinVDBaseEntity, new()
    {
        public XinVDBaseController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpPost]
        public override async Task<ActionResult<DataRes<bool>>> Delete(string id)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                bool cp = await CheckPermission("Delete", uow);
                if (cp)
                {
                    try
                    {
                        var repository = uow.GetRepository<TEntity>();
                        var model = repository.Get(id);
                        string us = User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Sid)).Value;
                        if (us != null)
                        {
                            int userid = Convert.ToInt32(us);
                            model.StopFlag = true;
                            model.WriteUid = userid;
                            model.WriteDate = DateTime.Now;
                            repository.Update(model);
                            uow.SaveChanges();
                        }
                        else
                        {
                            res.code = ResCode.Error;
                            res.data = false;
                            res.msg = "当前登录用户信息获取失败";
                        }
                        return res;
                    }
                    catch (Exception ex)
                    {
                        res.code = ResCode.ServerError;
                        res.msg = $"{ex.Message}:{ex.InnerException.Message}";
                        return res;
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetList")]
        public override async Task<ActionResult<DataRes<List<TEntity>>>> GetList([FromBody]BaseReq req)
        {
            var result = new DataRes<List<TEntity>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                bool cp = await CheckPermission("Read", uow);
                if (cp)
                {
                    try
                    {
                        var repository = uow.GetRepository<TEntity>();
                        var orderby = new OrderBy<TEntity>(req.order.columnName, req.order.reverse);
                        var models = await repository.NQueryAsync(f => f.StopFlag == false, orderby.Expression, req.navPropertyPaths);
                        result.data = models.ToList();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.code = ResCode.ServerError;
                        result.msg = $"{ex.Message}:{ex.InnerException.Message}";
                        return result;
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
        }


    }

    public abstract class XinVDPageBaseController<TEntity> : XinVDBaseController<TEntity> where TEntity : Entities.XinVDBaseEntity, new()
    {
        protected readonly IDataPager<TEntity> _dataPager;
        public XinVDPageBaseController(IUowProvider uowProvider, IDataPager<TEntity> dataPager) : base(uowProvider)
        {
            _dataPager = dataPager;
        }

        /// <summary>
        /// 获取用户分页
        /// </summary>
        /// <returns></returns>
        [Route("GetPage")]
        [HttpPost]
        public virtual async Task<ActionResult<PageDateRes<TEntity>>> GetPageAsync([FromBody]PageDataReq pageReq)
        {
            bool cp = false;
            using (var uow = _uowProvider.CreateUnitOfWork())
                cp = await CheckPermission("Edit", uow);
            if (cp)
            {
                var page = new PageDateRes<TEntity>();
                try
                {
                    string parameterstr = _typeName + "Page";
                    if (pageReq != null)
                    {
                        var query = pageReq.query;
                        query.Add(new FilterNode
                        {
                            andorop = "and",
                            key = "StopFlag",
                            binaryop = "eq",
                            value = false
                        });
                        var fuc = FilterHelper<TEntity>.GetExpression(query, parameterstr);
                        var filter = new Repository.Filter<TEntity>(fuc);
                        if (pageReq.order == null)
                        {
                            pageReq.order.columnName = "Id";
                            pageReq.order.reverse = false;
                        }
                        var orderBy = new Repository.OrderBy<TEntity>(pageReq.order.columnName, pageReq.order.reverse);
                        try
                        {
                            var result = await _dataPager.QueryAsync(pageReq.pageNum, pageReq.pageSize, filter,
                                orderBy, pageReq.navPropertyPaths);

                            page = PageMapper<TEntity>.ToPageDateRes(result);
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
                catch (Exception ex)
                {
                    page.code = ResCode.ServerError;
                    page.msg = $"{ex.Message}:{ex.InnerException.Message}";
                    return page;
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
