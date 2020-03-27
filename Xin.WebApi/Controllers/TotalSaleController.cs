using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Model;
using Xin.Web.Framework.Permission;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TotalSaleController : BaseController<TotalSale>
    {
        private readonly IUowProvider _uowProvider;
        public TotalSaleController(IUowProvider uowProvider) : base(uowProvider)
        {
            _uowProvider = uowProvider;
        }
        [PermissionFilter("TotalSale.Read")]
        [HttpPost]
        public ActionResult<DataRes<List<TotalSale>>> Index([FromBody]ReqTimeBetween req)
        {
            var res = new DataRes<List<TotalSale>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var sdatep = new SqlParameter("@Sdate", req.startTime);
                var edatep = new SqlParameter("@Edate", req.endTime);

                var repository = uow.GetRepository<TotalSale>();
                var data = repository.FromProcedure("EXECUTE TotalSale_sp @Sdate,@Edate", sdatep, edatep).ToList();
                res.data = data;
                return res;
            }
        }

        [PermissionFilter("TotalSale.Read")]
        [Route("GetProductCategoryList")]
        [HttpPost]
        public ActionResult<DataRes<List<string>>> GetProductCategoryList()
        {
            var result = new DataRes<List<string>>() { code = ResCode.Success };
            string[] arr = {"生发发帘","生发小发块","生发大发块","360发块","透明蕾丝发块","老接发","新接发",
                "高质量接发","化纤接发","顺发","UNICE新幅度","压色","辫发" ,"老发帘","人发头套-自产",
                "人发头套-组合","老头套","化纤头套"};
            result.data = arr.ToList();
            return result;
        }
    }
}