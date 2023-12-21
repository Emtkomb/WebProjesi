using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.ViewComponents.Default
{
    public class _HeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
