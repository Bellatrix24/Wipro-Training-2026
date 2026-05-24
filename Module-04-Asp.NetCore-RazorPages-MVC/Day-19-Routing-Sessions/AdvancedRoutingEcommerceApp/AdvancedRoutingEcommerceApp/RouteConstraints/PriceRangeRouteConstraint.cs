using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AdvancedRoutingEcommerceApp.RouteConstraints
{
    public class PriceRangeRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                var valueString = value.ToString();
                if (string.IsNullOrEmpty(valueString))
                {
                    return false;
                }

                var parts = valueString.Split('-');
                if (parts.Length == 2)
                {
                    if (decimal.TryParse(parts[0], out var minPrice) &&
                        decimal.TryParse(parts[1], out var maxPrice))
                    {
                        return minPrice >= 0 && maxPrice >= minPrice;
                    }
                }
            }
            return false;
        }
    }
}
