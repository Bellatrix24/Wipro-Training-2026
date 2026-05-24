using System;
using Microsoft.AspNetCore.Http;

namespace MvcFiltersBankingStoreApp.Services
{
    public class UserRoleService
    {
        public bool IsUserInRole(HttpContext context, string role)
        {
            if (context == null) return false;

            // Check the query string parameter role for demo purposes
            if (context.Request.Query.TryGetValue("role", out var roleValue))
            {
                return string.Equals(roleValue.ToString(), role, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
