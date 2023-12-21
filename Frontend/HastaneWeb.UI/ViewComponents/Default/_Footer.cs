using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.ViewComponents.Default
{
    public class _Footer:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
