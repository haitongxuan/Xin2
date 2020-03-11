using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xin.Entities;
using Xin.Repository;
using Xin.Service;
using Xin.Web.Framework.Model;

namespace Xin.Web.Framework.Controllers
{
    public class ECBaseController<TEntity> : ControllerBase where TEntity : class, new()
    {

        protected readonly IUowProvider _uowProvider;
        public ECBaseController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }
    }

    public class ECReadBaseController<TEntity> : ECBaseController<TEntity> where TEntity : class, new()
    {
        public ECReadBaseController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetList")]
        public virtual async Task<ActionResult<DataRes<List<TEntity>>>> GetList(NavigateOrderReq req)
        {
            var result = new DataRes<List<TEntity>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
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
                    result.msg = ex.Message;
                    return result;
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
                try
                {
                    var repository = uow.GetRepository<TEntity>();
                    var models = await repository.NGetAsync(req.Id, req.navPropertyPaths);
                    res.data = models;
                    return res;
                }
                catch (Exception ex)
                {
                    res.code = ResCode.ServerError;
                    res.msg = ex.Message;
                    return res;
                }
            }
        }
    }
}
