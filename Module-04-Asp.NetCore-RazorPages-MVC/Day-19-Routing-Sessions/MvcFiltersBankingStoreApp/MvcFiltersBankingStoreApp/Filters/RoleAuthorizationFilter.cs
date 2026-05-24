using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MvcFiltersBankingStoreApp.Services;

namespace MvcFiltersBankingStoreApp.Filters
{
    public class RoleAuthorizationFilter : IAuthorizationFilter
    {
        private readonly UserRoleService _roleService;
        private readonly string _requiredRole;

        public RoleAuthorizationFilter(UserRoleService roleService)
        {
            _roleService = roleService;
            _requiredRole = "admin"; // Default required role for admin actions
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_roleService.IsUserInRole(context.HttpContext, _requiredRole))
            {
                // Return a clear Access Denied response
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = $"Access Denied: You do not have the required role '{_requiredRole}' to view this page."
                };
            }
        }
    }
}
