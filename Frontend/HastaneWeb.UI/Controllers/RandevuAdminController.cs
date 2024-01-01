
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Dtos.RandevuDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace HastaneWeb.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RandevuAdminController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;

        public RandevuAdminController(Context context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.Randevular.Include(r => r.Doktor).Include(r => r.AppUser);


            return View(await context.ToListAsync());
        
        

        }


    }
}
