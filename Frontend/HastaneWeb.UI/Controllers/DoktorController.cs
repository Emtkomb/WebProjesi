﻿using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace HastaneWeb.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoktorController : Controller
    {


        private readonly Context _context;
        public DoktorController(Context context)
        {
            _context = context;
        }
       


        public async Task<IActionResult> Index()
        {
            var context = _context.Doktorlar.Include(d => d.Birim).ThenInclude(b => b.Hastane);
            return View(await context.ToListAsync());
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:5083/api/Doktor");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultDoktorDto>>(jsonData);
            //    return View(values);
            //}
            //return View();

        }
        [HttpGet]
        public IActionResult AddDoktor()
        {
            var birimList = _context.Birimler
                .Select(p => new { Id = p.BirimID, Display = $"{p.Name} - {p.BirimID}" })
                .ToList();
            var hastaneList = _context.Hastaneler
                .Select(p => new { Id = p.HastaneID, Display = $"{p.HastaneAdi} - {p.HastaneID}" })
                .ToList();

            ViewData["Birimler"] = new SelectList(birimList, "Id", "Display");
            ViewData["Hastaneler"] = new SelectList(hastaneList, "Id", "Display");
           

            return View();

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:5083/api/Doktor");

            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultDoktorDto>>(jsonData);
            //List<SelectListItem> values2 = (from x in values
            //                                select new SelectListItem
            //                                {
            //                                    Text = x.DoktorName,
            //                                    Value = x.DoktorID.ToString()

            //                                }).ToList();
            //ViewBag.v = values2;
            //return View();




        }
        [HttpPost]
        public async Task<IActionResult> AddDoktor([Bind("DoktorID,DoktorName,DoktorTelefon,DoktorMail,DoktorResim,GirisTarih,CikisTarih,BirimID,HastaneID")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BirimID"] = new SelectList(_context.Birimler, "BirimID", "Name", doktor.BirimID);
            ViewData["Hastaneler"] = new SelectList(_context.Hastaneler, "HastaneID", "HastaneAdi", doktor.Hastane.HastaneID);
            return View(doktor);
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(model);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("http://localhost:5083/api/Doktor", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }
        public async Task<IActionResult> DeleteDoktor(int? id)
        {
            if (id == null || _context.Doktorlar == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .Include(x => x.Birim)
                .FirstOrDefaultAsync(x => x.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"http://localhost:5083/api/Doktor/{id}");
            //if(responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }
        [HttpPost, ActionName("DeleteDoktor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Doktorlar == null)
            {
                return Problem("Entity set Doktorlar  is null.");
            }
            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktorlar.Remove(doktor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDoktor(int? id)
        {
            if (id == null || _context.Doktorlar == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }

            // Buraya ekleyeceğiniz kısım
            var birimList = _context.Birimler
                .Select(x => new { Id = x.BirimID, Display = $"{x.Name} - {x.HastaneID}" })
                .ToList();

            var hastaneList = _context.Hastaneler
               .Select(p => new { Id = p.HastaneID, Display = $"{p.HastaneAdi} - {p.HastaneAdi}" })
               .ToList();
            ViewData["BirimID"] = new SelectList(birimList, "Id", "Display");
            ViewData["Hastaneler"] = new SelectList(hastaneList, "Id", "Display");
            // --------------------------------

            return View(doktor);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"http://localhost:5083/api/Doktor/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateDoktorDto>(jsonData);
            //    return View(values);
            //}
            //return View();

        }
        [HttpPost]
       
        public async Task<IActionResult> UpdateDoktor(int? id, [Bind("DoktorID,DoktorName,DoktorTelefon,DoktorMail,DoktorResim,GirisTarih,CikisTarih,BirimID,HastaneID")] Doktor doktor)
        {
            if (id != doktor.DoktorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorID))
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
            ViewData["BirimID"] = new SelectList(_context.Birimler, "BirimID", "Name", doktor.BirimID);
            ViewData["Hastaneler"] = new SelectList(_context.Hastaneler, "HastaneID", "HastaneAdi", doktor.Hastane.HastaneID);
            return View(doktor);
            //    var client = _httpClientFactory.CreateClient();
            //    var jsonData = JsonConvert.SerializeObject(model); 
            //    StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            //    var responseMessage = await client.PutAsync("http://localhost:5083/api/Doktor/",stringContent);
            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //    return View();

        }
        private bool DoktorExists(int? id)
        {
            return (_context.Doktorlar?.Any(x => x.DoktorID == id)).GetValueOrDefault();
        }
    }
}
