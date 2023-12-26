using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.Controllers
{
    public class DefaultController : Controller
    {
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
