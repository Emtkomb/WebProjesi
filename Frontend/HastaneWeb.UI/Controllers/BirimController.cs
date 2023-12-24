using HastaneWeb.UI.Dtos.BirimDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HastaneWeb.UI.Controllers
{
    public class BirimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //private readonly IHttpClientFactory _httpClientFactory;

        //public BirimController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:5083/api/Birim");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultBirimDto>>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult AddBirim()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddBirim(CreateBirimDto createBirimDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createBirimDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("http://localhost:5083/api/Birim", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public async Task<IActionResult> DeleteBirim(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync($"http://localhost:5083/api/Birim/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> UpdateBirim(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"http://localhost:5083/api/Birim/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateBirimDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();

        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateBirim(UpdateBirimDto updateBirimDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateBirimDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("http://localhost:5083/api/Birim/", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}
    }
}
