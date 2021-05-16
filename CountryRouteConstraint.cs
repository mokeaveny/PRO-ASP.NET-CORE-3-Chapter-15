using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ASP.NET_CORE_3_Chapter_15
{

    public class CountryRouteConstraint : IRouteConstraint
    {
        private static string[] countries = { "uk", "france", "monaco" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
                RouteValueDictionary values, RouteDirection routeDirection)
        {
            string segmentValue = values[routeKey] as string ?? "";
            return Array.IndexOf(countries, segmentValue.ToLower()) > -1;
        }
    }
}