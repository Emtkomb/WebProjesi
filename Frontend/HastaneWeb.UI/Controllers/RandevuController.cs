using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.BusinessLayer.Concrete;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.DataAccessLayer.EntityFramework;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.DoktorDto;
using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Dtos.RandevuDto;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class RandevuController : Controller
    {


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

        private readonly IRandevuService _randevuService;

        public RandevuController(IRandevuService randevuService)
        {
            _randevuService = randevuService;
        }

        public IActionResult Index()
        {
            var values = _randevuService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult RandevuEkle()
        {
            return View();
        }
     
     
        [HttpPost]
        public IActionResult RandevuEkle(Randevu randevu)
        {

            _randevuService.TInsert(randevu);
            return RedirectToAction("Index");

        }
        
    }
}
