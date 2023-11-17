using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace Lusitan.GPES.WebApi.Extensions
{
    public class LocalizationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var cultureKey = context.Request.Headers["Accept-Language"];
            if (!string.IsNullOrEmpty(cultureKey))
            {
                if (DoesCultureExist(cultureKey))
                {
                    var culture = new CultureInfo(cultureKey);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }
            await next(context);
        }
        private static bool DoesCultureExist(string cultureName)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Any(culture => string.Equals(culture.Name, cultureName,
              StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
