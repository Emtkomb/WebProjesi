using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.BirimDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace HastaneWeb.UI.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class BirimController : Controller
    {

        private readonly Context _context;

        public BirimController(Context context)
        {
            _context = context;
        }

        //private readonly IHttpClientFactory _httpClientFactory;

        //public BirimController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public async Task<IActionResult> Index()
        {

            return _context.Birimler != null ?
                          View(await _context.Birimler.ToListAsync()):Problem("Entity set Birimler is null.");
        }
        [HttpGet]
        public IActionResult AddBirim()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBirim([Bind("BirimID,Name")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(birim);
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createBirimDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("http://localhost:5083/api/Birim", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }

        public async Task<IActionResult> DeleteBirim(int id)
        {
            var birim = await _context.Birimler
                .FirstOrDefaultAsync(m => m.BirimID == id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"http://localhost:5083/api/Birim/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }

        [HttpPost, ActionName("DeleteBirim")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Birimler == null)
            {
                return Problem("Entity set birimler  is null.");
            }
            var poliklinik = await _context.Birimler.FindAsync(id);
            if (poliklinik != null)
            {
                _context.Birimler.Remove(poliklinik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBirim(int id)
        {
            if (id == null || _context.Birimler == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Birimler.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            return View(poliklinik);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"http://localhost:5083/api/Birim/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateBirimDto>(jsonData);
            //    return View(values);
            //}
            //return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBirim(int id, [Bind("BirimID,Name")] Birim birim)
        {
            if (id != birim.BirimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliklinikExists(birim.BirimID))
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
            return View(birim);
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateBirimDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("http://localhost:5083/api/Birim/", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();

        }
        private bool PoliklinikExists(int id)
        {
            return (_context.Birimler?.Any(e => e.BirimID == id)).GetValueOrDefault();
        }
    }
}
