using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RoleRightApp.DannyHandler
{
    public class PoliciesAuthorizationHandler : AuthorizationHandler<UserRequireClaim>
    {
        public PoliciesAuthorizationHandler()
        {
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequireClaim requirement)
        {
            if (context.User == null) {
                System.Console.WriteLine("hello");
                context.Fail();
                return Task.CompletedTask;
            }
            context.Succeed( requirement);
            return Task.CompletedTask;
        }
    }
}