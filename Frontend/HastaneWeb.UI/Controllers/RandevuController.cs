using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.BusinessLayer.Concrete;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.DataAccessLayer.EntityFramework;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.DoktorDto;
using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Dtos.RandevuDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace HastaneWeb.UI.Controllers
{
  
    public class RandevuController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public RandevuController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var context = _context.Randevular.Include(r => r.Doktor).Include(r => r.AppUser);
            return View(await context.ToListAsync());
        

        }
        [HttpGet]
        public async Task<IActionResult> AddRandevuAsync()
        {
            var doktorList = _context.Doktorlar
                            .Select(p => new { Id = p.DoktorID, Display = $"{p.DoktorName} - {p.DoktorID}" })
                            .ToList();
            //var UserList = _userManager.Users
            //              .Select(p => new { Id = p.Id, Display = $"{p.Name} - {p.Id}" })
            //              .ToList();
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            // Create a collection with only the currently logged-in user
            var userList = new List<object> { new { Id = currentUser.Id, Display = $"{currentUser.Name} - {currentUser.Id}" } };
            var userListtel = new List<object> { new { Id = currentUser.Id, Display = $"{currentUser.PhoneNumber} - {currentUser.Id}" } };

            ViewData["Doktorlar"] = new SelectList(doktorList, "Id", "Display");
            ViewData["Users"] = new SelectList(userList, "Id", "Display");
            ViewData["Userstel"] = new SelectList(userListtel, "Id", "Display");

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddRandevu([Bind("RandevuID,TelNo,RandevuTarihi,Sikayet,DoktorID,AppUserId")] Randevu randevu)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Default");
            }
            ViewData["DoktorID"] = new SelectList(_context.Doktorlar, "DoktorID", "DoktorName", randevu.DoktorID);
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "Name", randevu.AppUserId);
            return View(randevu);

        }

        public async Task<IActionResult> DeleteRandevu(int? id)
        {

            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(x => x.Doktor)
                .FirstOrDefaultAsync(x => x.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
  
        }

        [HttpPost, ActionName("DeleteRandevu")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Randevular == null)
            {
                return Problem("Entity set Randevuler  is null.");
            }
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRandevu(int? id)
        {
            if (id == null || _context.Doktorlar == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }

            // Buraya ekleyeceğiniz kısım
            var doktorList = _context.Doktorlar
                .Select(x => new { Id = x.DoktorID, Display = $"{x.DoktorName} - {x.DoktorID}" })
                .ToList();
            var UserList = _userManager.Users
               .Select(x => new { Id = x.Id, Display = $"{x.Name} - {x.Id}" })
               .ToList();

            ViewData["DoktorID"] = new SelectList(doktorList, "Id", "Display");
            ViewData["Users"] = new SelectList(UserList, "Id", "Display");
            return View(randevu);
     

        }
        [HttpPost]
        public async Task<IActionResult> UpdateRandevu(int? id, [Bind("RandevuID,AppUserId,DoktorID")] Randevu randevu)
        {
            if (id != randevu.RandevuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.RandevuID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoktorID"] = new SelectList(_context.Doktorlar, "DoktorID", "DoktorName", randevu.DoktorID);
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "Name", randevu.AppUserId);
            return View(randevu);
           

        }
        private bool RandevuExists(int? id)
        {
            return (_context.Randevular?.Any(e => e.RandevuID == id)).GetValueOrDefault();
        }

        ////RandevuManager randevuManager = new RandevuManager(new EfRandevuDal());
        //private readonly IHttpClientFactory _httpClientFactory;

        //public RandevuController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        //public async Task<ActionResult> Index()
        //{


        //    //var client = _httpClientFactory.CreateClient();
        //    //var responseMessage = await client.GetAsync("http://localhost:5083/api/Doktor");

        //    //var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    //var values = JsonConvert.DeserializeObject<List<ResultDoktorDto>>(jsonData);
        //    //List<SelectListItem> values2 = (from x in values
        //    //                                select new SelectListItem
        //    //                                {
        //    //                                    Text = x.DoktorName,
        //    //                                    Value = x.DoktorID.ToString()

        //    //                                }).ToList();
        //    //ViewBag.v = values2;
        //    return View();


        //}
        //[HttpGet]
        //public PartialViewResult RandevuEkle()
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public async Task<IActionResult> RandevuEkle(CreateRandevuDto createRandevuDto)
        //{



        //    createRandevuDto.Status = "Onay Bekliyor";
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createRandevuDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    await client.PostAsync("http://localhost:5083/api/Randevu", stringContent);
        //    return RedirectToAction("Index", "Default");
        //}





    }
}
