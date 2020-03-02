using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xin.Common;
using Xin.Repository;
using Xin.WebApi.Model;
using Xin.Entities;
using Microsoft.EntityFrameworkCore;
using Xin.Web.Framework.Model;
using System;
using System.Linq;
using System.Security.Claims;
using Xin.Web.Framework.Permission;
using Xin.Web.Framework.Helper;
using Xin.Service;
using Xin.Web.Framework;

namespace Xin.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/User")]
    public class ResUserController : XinVDPageBaseController<ResUser>
    {
        private readonly IUowProvider _uowProvider;
        private readonly IDataPager<ResUser> _dataPager;
        public ResUserController(IUowProvider uowProvider, IDataPager<ResUser> dataPager) : base(uowProvider, dataPager)
        {
            _uowProvider = uowProvider;
            _dataPager = dataPager;
        }


        [HttpGet, Route("GetAccess")]
        public dynamic GetAccess()
        {
            var userName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var userCode = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.GivenName)).Value;
            var userId = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Sid)).Value;
            return new
            {
                avatar = "https://file.iviewui.com/dist/a0e88e83800f138b94d2414621bd9704.png",
                name = userName,
                user_id = userId,
                user_code = userCode
            };
        }
        

        /// <summary>
        /// 获取用户的权限列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserPermissions")]
        [PermissionFilter("User.Edit")]
        public async Task<DataRes<List<ResPermission>>> GetUserPermissionsAsync(int userId)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var cr = uow.GetCustomRepository<Service.IResUserRepository>();
                var list = (await cr.GetAllPermissions(userId)).ToList();
                var dr = new DataRes<List<ResPermission>>() { data = list };
                return dr;
            }
        }
    }

}
