﻿using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.ViewComponents.Default
{
    public class _DoktorMessage:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
