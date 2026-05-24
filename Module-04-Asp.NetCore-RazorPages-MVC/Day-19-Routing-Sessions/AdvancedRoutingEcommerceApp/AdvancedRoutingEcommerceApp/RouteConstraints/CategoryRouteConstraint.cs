using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AdvancedRoutingEcommerceApp.RouteConstraints
{
    public class CategoryRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                var category = value.ToString()?.ToLowerInvariant();
                return category == "electronics" || category == "books";
            }
            return false;
        }
    }
}
