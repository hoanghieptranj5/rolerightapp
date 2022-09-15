using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;  
using Microsoft.AspNetCore.Authorization.Infrastructure;  
namespace RoleRightApp.DannyHandler
{
    public class RoleHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated) {
                context.Fail();
                return Task.CompletedTask;
            }
            context.Succeed( requirement);
            return Task.CompletedTask;
        }
    }
}