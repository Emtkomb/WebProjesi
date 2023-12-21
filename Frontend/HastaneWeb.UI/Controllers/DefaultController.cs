using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
