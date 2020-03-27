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
    public class HairWeftStyleSaleController : BaseController<HairWeftStyleSale>
    {
        private readonly IUowProvider _uowProvider;
        public HairWeftStyleSaleController(IUowProvider uowProvider) : base(uowProvider)
        {
            _uowProvider = uowProvider;
        }

        [PermissionFilter("TotalSale.Read")]
        [HttpPost]
        public ActionResult<DataRes<List<HairWeftStyleSale>>> Index([FromBody]ReqTimeBetween req)
        {
            var res = new DataRes<List<HairWeftStyleSale>>() { code = ResCode.Success };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var sdatep = new SqlParameter("@Sdate", req.startTime);
                var edatep = new SqlParameter("@Edate", req.endTime);

                var repository = uow.GetRepository<HairWeftStyleSale>();
                var data = repository.FromProcedure("EXECUTE HairWeftStyleSale_sp @Sdate,@Edate", sdatep, edatep).ToList();
                res.data = data;
                return res;
            }
        }
    }
}