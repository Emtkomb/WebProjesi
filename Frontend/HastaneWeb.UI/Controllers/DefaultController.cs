using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        //[AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
           Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),new CookieOptions()
               {
                   Expires= DateTimeOffset.UtcNow.AddYears(1)
               });
            return Redirect(Request.Headers["Refere"].ToString());
        }
    }
}
