using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MvcFiltersBankingStoreApp.Services;

namespace MvcFiltersBankingStoreApp.Filters
{
    public class SimpleAuthenticationFilter : IAuthorizationFilter
    {
        private readonly AuthService _authService;

        public SimpleAuthenticationFilter(AuthService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_authService.IsUserLoggedIn(context.HttpContext))
            {
                // Redirect guest users to Account/Login
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
