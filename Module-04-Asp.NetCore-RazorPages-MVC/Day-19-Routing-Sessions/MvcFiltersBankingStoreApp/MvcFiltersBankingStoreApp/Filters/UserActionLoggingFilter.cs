using System;
using Microsoft.AspNetCore.Mvc.Filters;
using MvcFiltersBankingStoreApp.Services;

namespace MvcFiltersBankingStoreApp.Filters
{
    public class UserActionLoggingFilter : IActionFilter
    {
        private readonly LoggingService _loggingService;
        private readonly AuthService _authService;

        public UserActionLoggingFilter(LoggingService loggingService, AuthService authService)
        {
            _loggingService = loggingService;
            _authService = authService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var username = _authService.GetCurrentUsername(context.HttpContext);
            var actionName = context.RouteData.Values["action"]?.ToString() ?? "UnknownAction";
            
            _loggingService.LogUserAction(username, $"Performing action: {actionName}", DateTime.Now);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Executed after action runs
        }
    }
}
