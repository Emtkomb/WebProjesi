using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Models.Doktor;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HastaneWeb.UI.ViewComponents.Default
{
    public class _HizmetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HizmetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5083/api/Hizmet");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultHizmetDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
