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
          
            return View();
        }
     
    }
}
