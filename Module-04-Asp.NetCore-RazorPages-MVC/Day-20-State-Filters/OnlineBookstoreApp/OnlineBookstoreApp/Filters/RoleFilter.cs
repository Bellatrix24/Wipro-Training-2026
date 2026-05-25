using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBookstoreApp.Filters
{
    public class RoleFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = context.HttpContext.Session;
            var role = session.GetString("Role");

            if (string.IsNullOrEmpty(role) || role != "Admin")
            {
                // Return 403 Forbidden content for unauthorized users
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = "Access Denied: Admin administrative privileges are required to access this resource."
                };
            }
        }
    }
}
