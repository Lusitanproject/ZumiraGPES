using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Lusitan.GPES.Front.Blazor.Controller
{
	[Route("[controller]/[action]")]
	public class CulturaController : ControllerBase
	{
		public IActionResult SetCultura(string cultura, string url)
		{
			if (cultura != null)
			{
				HttpContext.Response.Cookies.Append(
					CookieRequestCultureProvider.DefaultCookieName,
					CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultura)));
			}

			return LocalRedirect(url);
		}
	}
}
