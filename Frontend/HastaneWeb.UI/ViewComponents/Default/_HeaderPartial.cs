using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.ViewComponents.Default
{
    public class _HeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
