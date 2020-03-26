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
        public ActionResult<DataRes<List<TotalSale>>> Index(DateTime? startDatetime = null, DateTime? endDatetime = null)
        {
            var res = new DataRes<List<TotalSale>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var sdatep = new SqlParameter("@Sdate", startDatetime);
                var edatep = new SqlParameter("@Edate", endDatetime);

                var repository = uow.GetRepository<TotalSale>();
                var data = repository.FromProcedure("EXECUTE TotalSale_sp @Sdate,@Edate", sdatep, edatep).ToList();
                res.data = data;
                return res;
            }
        }
    }
}