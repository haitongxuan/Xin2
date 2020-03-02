using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Entities;

namespace Xin.Service
{
    public interface IResUserRepository :IXinRepository<ResUser>
    {
        /// <summary>
        /// 根据用户名密码获取用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IEnumerable<ResUser>> GetUserByUP(string username, string password);
        /// <summary>
        /// 验证用户权限
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        Task<bool> CheckPermission(string userCode, string permissionName);

        /// <summary>
        /// 获取用户的全部信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<List<ResPermission>> GetAllPermissions(int userId);
    }
}
