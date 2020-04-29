using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Common;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
using Xin.Web.Framework.Helper;
using Xin.Web.Framework.Model;

namespace Xin.WebApi.Controllers
{
    /// <summary>
    /// 美国仓unice货物和通用货物剩余库存报表
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsUiceNomalSkuQtyController : ControllerBase
    {
        private IUowProvider _uowProvider;

        public UsUiceNomalSkuQtyController(IUowProvider uowProvider)
        {
            var config = new AppConfigurationServices().Configuration;
            _uowProvider = uowProvider;
        }
        /// <summary>
        /// 物流详情
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [Route("GetList")]
        [HttpPost]
        public GridPage<List<UsUiceNomalSkuQtyReport>> GetList(DatetimePointPageReq pageReq)
        {

            var res = new GridPage<List<UsUiceNomalSkuQtyReport>>() { code = ResCode.Success };
            res = DataBaseHelper<UsUiceNomalSkuQtyReport>.GetFromProcedure(_uowProvider, res, pageReq, false, "EXECUTE UsUiceNomalSkuQty_sp");

            return res;
        }


    }
}