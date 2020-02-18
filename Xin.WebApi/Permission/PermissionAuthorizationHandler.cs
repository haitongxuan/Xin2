using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xin.Entities;
using Xin.Service;

namespace Xin.WebApi.Permission
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly Repository.IUowProvider _uowProvider;
        public PermissionAuthorizationHandler(Repository.IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            if (context.User != null)
            {
                if (context.User.IsInRole("Admin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    using (var uow = _uowProvider.CreateUnitOfWork())
                    {
                        var repository = uow.GetRepository<ResUser>();
                        var cRepository = uow.GetCustomRepository<IResUserRepository>();
                        var userIdClaim = context.User.FindFirst(p => p.Type == ClaimTypes.Name);
                        if (userIdClaim != null)
                        {
                            try
                            {
                                //userIdClaim.Value=ResUser.UserCode
                                var r = await cRepository.CheckPermission(userIdClaim.Value, requirement.Name);
                                if (r)
                                {
                                    context.Succeed(requirement);
                                }
                                else
                                {
                                    context.Fail();
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
        }
    }
}
