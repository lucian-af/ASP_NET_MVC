using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BookStore.RouteConstraint
{
    public class ValuesConstraint : IRouteConstraint
    {
        public readonly string[] validOptions;
        public ValuesConstraint(string options)
        {
            validOptions = options.Split('|');
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(parameterName, out object value) && !(value is null))
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}