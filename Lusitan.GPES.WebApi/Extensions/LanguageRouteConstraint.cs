using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Lusitan.GPES.WebApi.Extensions
{
    public class LanguageRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {

            if (!values.ContainsKey("cultura"))
                return false;

            var culture = values["cultura"].ToString();
            return culture == "pt-BR" || culture == "en-US" || culture == "es-AR";
        }
    }
}
