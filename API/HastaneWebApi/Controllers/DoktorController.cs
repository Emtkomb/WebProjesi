using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoktorController : ControllerBase
    {
        private readonly IDoktorService _doktorService;

        public DoktorController(IDoktorService doktorService)
        {
            _doktorService = doktorService;
        }

        [HttpGet]
        public IActionResult DoktorList()
        {
            var values = _doktorService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult DoktorEkle(Doktor doktor)
        {
            _doktorService.TInsert(doktor);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DoktorSil(int id)
        {
            var values = _doktorService.TGetByID(id);
            _doktorService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult DoktorGüncelle(Doktor doktor)
        {

            _doktorService.TUpdate(doktor);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult DoktorGetir(int id)
        {
            var values = _doktorService.TGetByID(id);
            return Ok(values);
        }
    }
}
