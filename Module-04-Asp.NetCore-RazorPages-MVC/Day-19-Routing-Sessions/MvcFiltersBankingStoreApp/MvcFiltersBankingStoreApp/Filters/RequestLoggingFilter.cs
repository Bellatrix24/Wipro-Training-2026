using Microsoft.AspNetCore.Mvc.Filters;
using MvcFiltersBankingStoreApp.Services;

namespace MvcFiltersBankingStoreApp.Filters
{
    public class RequestLoggingFilter : IActionFilter
    {
        private readonly LoggingService _loggingService;

        public RequestLoggingFilter(LoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Executed before action runs
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;
            
            var url = request.Path + request.QueryString;
            var method = request.Method;
            var statusCode = response.StatusCode;

            _loggingService.LogRequest(url, method, statusCode);
        }
    }
}
