using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xin.Repository;
using Xin.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Xin.Web.Framework.Permission
{
    public class XinClaimsTransformer : IClaimsTransformation
    {
        private readonly IUowProvider _uowProvider;
        public XinClaimsTransformer(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var existingClaimsIdentity = (ClaimsIdentity)principal.Identity;
            var currentUserName = existingClaimsIdentity.Name;
            var claims = new List<Claim>{
                        new Claim(ClaimTypes.Name, currentUserName),
                        // Potentially add more from the existing claims here
                 };
            // Find the user in the DB
            // Add as many role claims as they have roles in the DB
            ResUser user;
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                //vs编辑器会提示错误信息对ThenInclude不用管他
                var respository = uow.GetRepository<ResUser>();
                var users = await respository.QueryAsync(
                    x => x.UserName.Equals(currentUserName, StringComparison.CurrentCultureIgnoreCase)
                    , null, x => x.Include(p => p.ResUserRoles)
                    .ThenInclude(q => q.ResRole));

                user = users.FirstOrDefault();

                if (user != null)
                {
                    var rolesNames = from r in user.ResUserRoles.Select(p => p.ResRole)
                                     select r.RoleCode;

                    var sid = new Claim(ClaimTypes.Sid, user.Id.ToString());
                    var giveName = new Claim(ClaimTypes.GivenName, user.UserCode);
                    var mobilePhone = new Claim(ClaimTypes.MobilePhone, user.Phone);
                    var groupSid = new Claim(ClaimTypes.GroupSid, user.DeptId.ToString());

                    claims.AddRange(rolesNames.Select(x => new Claim(ClaimTypes.Role, x)));
                    claims.Add(sid);
                    claims.Add(giveName);
                    claims.Add(mobilePhone);
                    claims.Add(groupSid);
                }
                var newClaimsIdentity = new ClaimsIdentity(claims, existingClaimsIdentity.AuthenticationType);
                return new ClaimsPrincipal(newClaimsIdentity);
            }
        }
    }
}
