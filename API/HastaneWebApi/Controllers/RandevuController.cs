using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevuController : ControllerBase
    {
        private readonly IRandevuService _RandevuService;

        public RandevuController(IRandevuService RandevuService)
        {
            _RandevuService = RandevuService;
        }

        [HttpGet]
        public IActionResult RandevuList()
        {
            var values = _RandevuService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult RandevuEkle(Randevu Randevu)
        {
            _RandevuService.TInsert(Randevu);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRandevu(int id)
        {
            var values = _RandevuService.TGetByID(id);
            _RandevuService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRandevu(Randevu Randevu)
        {

            _RandevuService.TUpdate(Randevu);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult RandevuGetir(int id)
        {
            var values = _RandevuService.TGetByID(id);
            return Ok(values);
        }
    }
}
