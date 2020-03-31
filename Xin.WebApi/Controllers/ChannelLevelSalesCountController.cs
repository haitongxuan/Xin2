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
    [ApiController]
    //[Authorize]
    public class ChannelLevelSalesCountController : BaseController<ChannelLevelSalesCount>
    {
        private readonly IUowProvider _uowProvider;
        public ChannelLevelSalesCountController(IUowProvider uowProvider) : base(uowProvider)
        {
            _uowProvider = uowProvider;
        }

        //[PermissionFilter("ChannelLevelSalesCount.Read")]
        [Route("index")]
        [HttpPost]
        public ActionResult<DataRes<List<PlateformLevel>>> Index([FromBody]ReqTimeBetween req)
        {
                DateTime dt = DateTime.Now;
                string startTime = req.startTime;
                string endTime = req.endTime;
                if (string.IsNullOrEmpty(startTime))
                {
                    startTime = dt.AddDays(1 - dt.Day).Date.ToString();
                }
                if (string.IsNullOrEmpty(endTime))
                {
                    endTime = dt.AddDays(1 - dt.Day).AddMonths(1).Date.ToString();
                }
                else
                {
                    endTime = DateTime.Parse(endTime).AddDays(1).Date.ToString();
                }
                if (string.IsNullOrWhiteSpace(req.type))
                {
                    req.type = "发块";
                }

                var res = new GridPage<List<PlateformLevel>>() { code = ResCode.Success };
                try
                {
                    using (var uow = _uowProvider.CreateUnitOfWork())
                    {
                        var sdatep = new SqlParameter("@Sdate", req.startTime);
                        var edatep = new SqlParameter("@Edate", req.endTime);
                        var type = new SqlParameter("@SaleType", req.type);

                    var repository = uow.GetRepository<PlateformLevel>();
                        var data = repository.FromProcedure("EXECUTE PlateformLevel_Sp @Sdate,@Edate,@SaleType", sdatep, edatep,type).ToList();
                        res.data = data;
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    res.code = ResCode.ServerError;
                    res.msg = ex.Message;
                }
                return res;
            
        }
    }
}