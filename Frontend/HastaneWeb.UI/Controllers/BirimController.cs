using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.BirimDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var context = _context.Birimler.Include(d => d.Hastane);
            return View(await context.ToListAsync());
            //    return _context.Birimler != null ?
            //                  View(await _context.Birimler.ToListAsync()):Problem("Entity set Birimler is null.");
        }
        [HttpGet]
        public IActionResult AddBirim()
        {
            var hastaneList = _context.Hastaneler
                            .Select(p => new { Id = p.HastaneID, Display = $"{p.HastaneAdi} - {p.HastaneID}" })
                            .ToList();

            ViewData["Hastaneler"] = new SelectList(hastaneList, "Id", "Display");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBirim([Bind("BirimID,Name,HastaneID")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HastaneID"] = new SelectList(_context.Hastaneler, "HataneID", "HastaneAdi", birim.HastaneID);
            return View(birim);
            //if (ModelState.IsValid)
            //{
            //    _context.Add(birim);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(birim);
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

        public async Task<IActionResult> DeleteBirim(int? id)
        {

            if (id == null || _context.Birimler == null)
            {
                return NotFound();
            }

            var birim = await _context.Birimler
                .Include(x => x.Hastane)
                .FirstOrDefaultAsync(x => x.BirimID == id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
            //var birim = await _context.Birimler
            //    .FirstOrDefaultAsync(m => m.BirimID == id);
            //if (birim == null)
            //{
            //    return NotFound();
            //}

            //return View(birim);
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
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Birimler == null)
            {
                return Problem("Entity set birimler  is null.");
            }
            var birim = await _context.Birimler.FindAsync(id);
            if (birim != null)
            {
                _context.Birimler.Remove(birim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBirim(int? id)
        {
            if (id == null || _context.Doktorlar == null)
            {
                return NotFound();
            }

            var birim = await _context.Birimler.FindAsync(id);
            if (birim == null)
            {
                return NotFound();
            }

            // Buraya ekleyeceğiniz kısım
            var hastaneList = _context.Hastaneler
                .Select(x => new { Id = x.HastaneID, Display = $"{x.HastaneAdi} - {x.HastaneID}" })
                .ToList();

            ViewData["HastaneID"] = new SelectList(hastaneList, "Id", "Display");
            return View(birim);
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
        public async Task<IActionResult> UpdateBirim(int? id, [Bind("BirimID,Name,HastaneID")] Birim birim)
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
                    if (!BirimExists(birim.BirimID))
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
            ViewData["HastaneID"] = new SelectList(_context.Hastaneler, "HastaneID", "HastaneAdi", birim.HastaneID);
            return View(birim);
            //    if (id != birim.BirimID)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            _context.Update(birim);
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!BirimExists(birim.BirimID))
            //            {
            //                return NotFound();
            //            }
            //            else
            //            {
            //                throw;
            //            }
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(birim);
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
        private bool BirimExists(int? id)
        {
            return (_context.Birimler?.Any(e => e.BirimID == id)).GetValueOrDefault();
        }
    }
}
