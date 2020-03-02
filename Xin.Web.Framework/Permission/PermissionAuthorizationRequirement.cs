using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Web.Framework.Permission
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }
        public PermissionAuthorizationRequirement(string name)
        {
            this.Name = name;
        }
    }
}
