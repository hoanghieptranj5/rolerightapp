using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RoleRightApp.DannyHandler
{
    public class UserRequireClaim : IAuthorizationRequirement
    {
        public string ClaimType { get; }
        public UserRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }

    
    }
}