using Microsoft.AspNetCore.Http;

namespace MvcFiltersBankingStoreApp.Services
{
    public class AuthService
    {
        public bool IsUserLoggedIn(HttpContext context)
        {
            if (context == null) return false;

            // Check the query string parameter loggedIn for demo purposes
            if (context.Request.Query.TryGetValue("loggedIn", out var loggedInValue))
            {
                return loggedInValue == "true";
            }

            return false;
        }

        public string GetCurrentUsername(HttpContext context)
        {
            if (context == null) return "Guest";

            if (context.Request.Query.TryGetValue("username", out var userValue) && !string.IsNullOrEmpty(userValue))
            {
                return userValue.ToString();
            }

            return "john"; // Default mock user
        }
    }
}
