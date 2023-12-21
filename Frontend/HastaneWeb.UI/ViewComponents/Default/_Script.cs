using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.ViewComponents.Default
{
    public class _Script:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
