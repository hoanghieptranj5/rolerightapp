using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;  

namespace RoleRightApp.DannyHandler
{
    public static class AuthorizationBuilderExtension
    {
        public static AuthorizationPolicyBuilder UserRequireClaim(this AuthorizationPolicyBuilder builder, string claimType)
        {
            builder.AddRequirements(new UserRequireClaim(claimType));
            return builder;
        }
    }
}