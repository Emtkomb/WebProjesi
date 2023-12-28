using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.HastaneDto;
using HastaneWeb.UI.Models.Hastane;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace HastaneWeb.UI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class HastaneController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public HastaneController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}
        private readonly Context _context;

        public HastaneController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Hastaneler != null ?
                         View(await _context.Hastaneler.ToListAsync()) : Problem("Entity set Birimler is null.");
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:5083/api/Hastane");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultHastaneDto>>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
        [HttpGet]
        public IActionResult AddHastane()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHastane([Bind("HasteneID,HastaneAdi,HastaneAdresi,HastaneTelefon,HastaneResim")] Hastane hastane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hastane);
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(model);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("http://localhost:5083/api/Hastane", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }
        public async Task<IActionResult> DeleteHastane(int? id)
        {
            var birim = await _context.Hastaneler
                  .FirstOrDefaultAsync(m => m.HastaneID == id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"http://localhost:5083/api/Hastane/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }
        [HttpPost, ActionName("DeleteHastane")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Hastaneler == null)
            {
                return Problem("Entity set birimler  is null.");
            }
            var hastane = await _context.Hastaneler.FindAsync(id);
            if (hastane != null)
            {
                _context.Hastaneler.Remove(hastane);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHastane(int? id)
        {

            if (id == null || _context.Hastaneler == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastaneler.FindAsync(id);
            if (hastane == null)
            {
                return NotFound();
            }
            return View(hastane);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"http://localhost:5083/api/Hastane/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateHastaneDto>(jsonData);
            //    return View(values);
            //}
            //return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateHastane(int? id, [Bind("HasteneID,HastaneAdi,HastaneAdresi,HastaneTelefon,HastaneResim")] Hastane hastane)
        {
            if (id != hastane.HastaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaneExists(hastane.HastaneID))
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
            return View(hastane);
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(model);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("http://localhost:5083/api/Hastane/", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();

        }

        
        private bool HastaneExists(int? id)
        {
            return (_context.Hastaneler?.Any(e => e.HastaneID == id)).GetValueOrDefault();
        }

    }
}
