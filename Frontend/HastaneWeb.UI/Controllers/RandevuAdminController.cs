
using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Dtos.RandevuDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HastaneWeb.UI.Controllers
{
    public class RandevuAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RandevuAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5083/api/Randevu");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRandevuDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> AppRovedRandevu(AppRovedRandevuDto appRovedRandevuDto)
        {
            appRovedRandevuDto.Status = "Onaylandı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(appRovedRandevuDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5083/api/Randevu/", stringContent);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
