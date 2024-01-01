using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.BusinessLayer.Concrete;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Areas.Hasta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace HastaneWeb.UI.Areas.Hasta.Controllers
{
	[Area("Hasta")]

	[Route("Hasta/[Controller]/[action]")]
	public class ProfileController : Controller
	{
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
		private readonly IRandevuService _randevuService;

        public ProfileController(Context context, UserManager<AppUser> userManager, IRandevuService randevuService)
        {
            _context = context;
            _userManager = userManager;
            _randevuService = randevuService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel=new UserEditViewModel();
			userEditViewModel.name= values.Name;
			userEditViewModel.surName= values.Surname;
			userEditViewModel.city= values.City;
			userEditViewModel.phoneNumber= values.PhoneNumber;
			userEditViewModel.city= values.City;
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult>Index(UserEditViewModel p)
		{
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
			user.Name = p.name;
			user.Surname = p.surName;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,p.password);
			var result = await _userManager.UpdateAsync(user);
			if(result.Succeeded)
			{
				return RedirectToAction("Index", "Profile");
			}
			return View();
					
        }
		public async Task<IActionResult> HastaRandevular()
		{
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var context = _context.Randevular.Include(r => r.Doktor).Include(r => r.AppUser);
            return View(await context.ToListAsync());
            //var valuesList = _randevuService.GetListRandevu(user.Id);
  

            //return View(valuesList);
   
            
        }
	}
}
