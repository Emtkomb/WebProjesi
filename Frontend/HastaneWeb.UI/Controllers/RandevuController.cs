using HastaneWeb.UI.Dtos.RandevuDto;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
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
