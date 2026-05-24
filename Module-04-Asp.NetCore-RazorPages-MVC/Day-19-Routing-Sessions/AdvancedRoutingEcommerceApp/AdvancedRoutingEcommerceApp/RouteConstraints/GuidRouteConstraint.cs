using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AdvancedRoutingEcommerceApp.RouteConstraints
{
    public class GuidRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                var valueString = value.ToString();
                return Guid.TryParse(valueString, out _);
            }
            return false;
        }
    }
}
