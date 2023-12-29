
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Dtos.RandevuDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace HastaneWeb.UI.Controllers
{
    public class RandevuAdminController : Controller
    {
        private readonly Context _context;

        public RandevuAdminController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.Randevular.Include(d => d.Doktor);
            return View(await context.ToListAsync());

        }


    }
}
