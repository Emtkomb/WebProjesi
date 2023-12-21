using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirimController : ControllerBase
    {
        private readonly IBirimService _BirimService;

        public BirimController(IBirimService BirimService)
        {
            _BirimService = BirimService;
        }

        [HttpGet]
        public IActionResult BirimList()
        {
            var values = _BirimService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult BirimEkle(Birim Birim)
        {
            _BirimService.TInsert(Birim);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult BirimSil(int id)
        {
            var values = _BirimService.TGetByID(id);
            _BirimService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult BirimGüncelle(Birim Birim)
        {

            _BirimService.TUpdate(Birim);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BirimGetir(int id)
        {
            var values = _BirimService.TGetByID(id);
            return Ok(values);
        }
    }
}
