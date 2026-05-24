using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareRazorPagesApp.Middleware
{
    // Natural comment: Custom middleware to log incoming request details and outgoing response status codes.
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log incoming request details
            _logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the request pipeline
            await _next(context);

            // Log outgoing response details
            _logger.LogInformation($"Outgoing Response Status Code: {context.Response.StatusCode}");
        }
    }
}
