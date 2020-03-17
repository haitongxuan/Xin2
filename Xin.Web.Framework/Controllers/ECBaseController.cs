using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class BaseController<TEntity> : ControllerBase where TEntity : class, new()
    {

        protected readonly IUowProvider _uowProvider;
        public BaseController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }
    }

    public abstract class ExcelImportController<TEntity> : ReadBaseController<TEntity> where TEntity : class, new()
    {
        public ExcelImportController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        /// <summary>
        /// 导入Excel数据
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("import")]
        public async Task<ActionResult<DataRes<bool>>> Import([FromForm]IFormFile excelFile)
        {
            DataRes<bool> result = new DataRes<bool>() { code = ResCode.Success, data = true };
            //IFormFile excelFile = files["excelfile"];
            if (excelFile == null || excelFile.Length <= 0)
            {
                result.code = ResCode.Error;
                result.data = false;
                result.msg = ResMsg.FileNotNull;
            }
            else if (!Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                result.code = ResCode.NoValidate;
                result.msg = ResMsg.ExcelNotValidate;
                result.data = false;

            }
            List<TEntity> list = null;
            using (var stream = excelFile.OpenReadStream())
            {
                using (var package = new ExcelPackage(stream))
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        list = GetEntitiesFromExcel(worksheet);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<TEntity>();
                await repository.BulkInsertAsync(list).ConfigureAwait(false);
            }
            return result;
        }

        protected abstract List<TEntity> GetEntitiesFromExcel(ExcelWorksheet sheet);
    }

    public class ReadBaseController<TEntity> : BaseController<TEntity> where TEntity : class, new()
    {
        public ReadBaseController(IUowProvider uowProvider) : base(uowProvider)
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
                    var models = await repository.NGetAllAsync(order != null ? order.Expression : null, req.navPropertyPaths);
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
