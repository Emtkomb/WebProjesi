using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HizmetController : ControllerBase
    {
        private readonly IHizmetService _hizmetService;

        public HizmetController(IHizmetService hizmetService)
        {
            _hizmetService = hizmetService;
        }

        [HttpGet]
        public IActionResult HizmetList()
        {
            var values = _hizmetService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult HizmetEkle(Hizmet hizmet)
        {
            _hizmetService.TInsert(hizmet);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteHizmet(int id)
        {
            var values = _hizmetService.TGetByID(id);
            _hizmetService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateHizmet(Hizmet hizmet)
        {

            _hizmetService.TUpdate(hizmet);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult HizmetGetir(int id)
        {
            var values = _hizmetService.TGetByID(id);
            return Ok(values);
        }
    }
}
