using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiddlewareRazorPagesApp.Middleware
{
    // Natural comment: Custom middleware to enforce Content Security Policy headers on all responses.
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Add a Content-Security-Policy header to secure the page against XSS and injection
            context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;");

            // Process the next middleware
            await _next(context);
        }
    }
}
