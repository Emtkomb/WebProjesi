﻿using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
