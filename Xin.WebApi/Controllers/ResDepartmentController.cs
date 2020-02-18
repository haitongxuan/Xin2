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
using Xin.Common.Model;

namespace LQExtension.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/ResDept")]
    public class ResDepartmentController : Controller
    {
        private readonly IUowProvider _uowProvicer;
        public ResDepartmentController(IUowProvider uowProvider)
        {
            _uowProvicer = uowProvider;
        }
        [HttpPost]
        [Route("GetList")]
        public DataRes<List<ResDepartment>> GetList()
        {
            var result = new DataRes<List<ResDepartment>>() { code = ResCode.Success };
            using (var uow = _uowProvicer.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResDepartment>();
                var depts = repository.Query(f => f.StopFlag == false);
                result.data = depts.ToList();
            }

            return result;
        }

        /// <summary>
        /// 获取子部门列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChildList/{id}")]
        public DataRes<List<ResDepartment>> GetChildList(int id)
        {
            var result = new DataRes<List<ResDepartment>>() { code = ResCode.Success };
            using (var uow = _uowProvicer.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResDepartment>();
                var depts = repository.Query(f => f.StopFlag == false && f.ParentId == id);
                result.data = depts.ToList();
            }

            return result;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public DataRes<bool> Add([FromBody]ResDepartment model)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvicer.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResDepartment>();
                string us = User.Claims.FirstOrDefault(p => p.Type.Equals("Sid")).Value;
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
            }

            return res;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [Route("Edit")]
        [HttpPost]
        public DataRes<bool> Edit([FromBody]ResDepartment model)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvicer.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResDepartment>();
                string us = User.Claims.FirstOrDefault(p => p.Type.Equals("Sid")).Value;
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
            }

            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpPost]
        public DataRes<bool> Delete(string id)
        {
            DataRes<bool> res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvicer.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResDepartment>();
                var model = repository.Get(id);
                string us = User.Claims.FirstOrDefault(p => p.Type.Equals("Sid")).Value;
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
            }

            return res;
        }
    }
}