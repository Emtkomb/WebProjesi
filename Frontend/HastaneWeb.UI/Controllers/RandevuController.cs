using HastaneWeb.UI.Dtos.DoktorDto;
using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Dtos.RandevuDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Text;

namespace HastaneWeb.UI.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RandevuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5083/api/Doktor");
                
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDoktorDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.DoktorName,
                                                Value= x.DoktorID.ToString()
                                                
                                            }).ToList();
            ViewBag.v=values2;
                return View();
          
           
        }
        [HttpGet]
        public PartialViewResult RandevuEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> RandevuEkle(CreateRandevuDto createRandevuDto)
        {
            createRandevuDto.Status = "Onay Bekliyor";
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createRandevuDto);
            StringContent stringContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            await client.PostAsync("http://localhost:5083/api/Randevu", stringContent);
            return RedirectToAction("Index","Default");
        }
    }
}
