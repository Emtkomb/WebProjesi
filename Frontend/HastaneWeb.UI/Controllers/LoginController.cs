using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);

                if (result.Succeeded)
                {
                    // Kullanıcı giriş yaptı, rol kontrolü yapalım
                    var user = await _userManager.FindByNameAsync(loginUserDto.Username);

                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        // Admin kullanıcı ise Admin sayfasına yönlendir
                        return RedirectToAction("Index", "Doktor");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "Member"))
                    {
                        // Member kullanıcı ise Member sayfasına yönlendir
                        return RedirectToAction("Index", "Default");
                    }
                }
                else
                {
                    // Giriş başarısızsa, tekrar login sayfasına yönlendir
                    return View();
                }
            }
            return View();
            //if(ModelState.IsValid)
            //{
            //    var result=await _signInManager.PasswordSignInAsync(loginUserDto.Username,loginUserDto.Password,false,false);
            //    if(result.Succeeded)
            //    {
            //        return RedirectToAction("Index","Randevu");
            //    }
            //    else
            //    {
            //        return View();
            //    }
            //}
            //return View();
        }
    }
}
