using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xin.Common;
using Xin.Entities;
using Xin.Repository;
using Xin.Service.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xin.Common.CustomAttribute;

namespace Xin.Service
{
    public class ResUserRepository :
        AutocodeBaseRepository<ResUser>,
        IResUserRepository
    {
        public ResUserRepository(XinDBContext context) : base(context)
        {
        }

        public ResUserRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }

        public override void Add(ResUser entity)
        {
            string salt = SecretHelper.GetSalt(true, 10);
            entity.UserPwd = SecretHelper.MD5Encrypt(entity.UserPwd, salt);
            entity.Salt = salt;
            base.Add(entity);
        }

        public async Task<IEnumerable<ResUser>> GetUserByUP(string username, string password)
        {
            try
            {
                var users = await this.QueryAsync(
                    x => x.UserName == username && x.UserPwd == Xin.Common.SecretHelper.MD5Encrypt(password, x.Salt),
                    null, x => x.Include(p => p.ResDepartment).ThenInclude(p => p.ChildrenDept));
                return users;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }

        public async Task<bool> CheckPermission(string userCode, string permissionName)
        {
            var r = await this.AnyAsync(x => x.ResUserRoles.Any(y => y.ResRole.ResRolePermissions.Any(z => z.ResPermission.PermissionCode == permissionName))
            && x.ResUserPermissions.Any(y => y.ResPermission.PermissionCode == permissionName));
            return r;
        }

        public async Task<List<ResPermission>> GetAllPermissions(int userId)
        {
            var permissions = new List<ResPermission>();

            var model = await this.GetAsync(userId, x => x.Include(p => p.ResUserPermissions)
                .ThenInclude(p => p.ResPermission)
                .Include(p => p.ResUserRoles)
                .ThenInclude(p => p.ResRole)
                .ThenInclude(p => p.ResRolePermissions)
                .ThenInclude(p => p.ResPermission))
                ;

            var pQuery = Context.Set<ResPermission>();
            foreach (var r in model.ResUserRoles)
            {
                foreach (var p in r.ResRole.ResRolePermissions)
                {
                    permissions.Add(p.ResPermission);
                }
            }
            foreach (var p in model.ResUserPermissions)
            {
                permissions.Add(p.ResPermission);
            }
            return permissions;
        }

    }
}
