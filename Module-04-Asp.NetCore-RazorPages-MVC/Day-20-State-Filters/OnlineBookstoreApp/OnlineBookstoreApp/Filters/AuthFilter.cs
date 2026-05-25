using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBookstoreApp.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = context.HttpContext.Session;
            var username = session.GetString("Username");

            if (string.IsNullOrEmpty(username))
            {
                // Redirect unauthorized users to the Razor Page login screen
                context.Result = new RedirectToPageResult("/Account/Login");
            }
        }
    }
}
