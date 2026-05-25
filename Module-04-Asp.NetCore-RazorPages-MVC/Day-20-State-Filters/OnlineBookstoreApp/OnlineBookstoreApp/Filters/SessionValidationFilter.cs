using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBookstoreApp.Filters
{
    public class SessionValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var username = session.GetString("Username");
            var role = session.GetString("Role");

            // Simple session integrity check: if username is present, role should be present
            if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(role))
            {
                session.Clear();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
