using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {
        private readonly IHastaneService _hastaneService;

        public HastaneController(IHastaneService hastaneService)
        {
            _hastaneService = hastaneService;
        }

        [HttpGet]
        public IActionResult HastaneList()
        {
            var values = _hastaneService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult HastaneEkle(Hastane Hastane)
        {
            _hastaneService.TInsert(Hastane);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult HastaneSil(int id)
        {
            var values = _hastaneService.TGetByID(id);
            _hastaneService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult HastaneGüncelle(Hastane Hastane)
        {

            _hastaneService.TUpdate(Hastane);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult HastaneGetir(int id)
        {
            var values = _hastaneService.TGetByID(id);
            return Ok(values);
        }
    }
}
