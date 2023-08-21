using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Abstract;
using Task.BLL.Concrete;
using Task.EntityLayer.DTOs;

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisService siparisService;

        public SiparisController(ISiparisService siparisService)
        {
            this.siparisService = siparisService;
        }

        [HttpGet("GetAllSiparis")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(siparisService.GetAll());
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }

        [HttpPost("CreateSiparis")]
        [AllowAnonymous]
        public IActionResult Add(SiparisDTO siparisUrun)
        {
            try
            {

                return Ok(siparisService.Add(siparisUrun));
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Kullanici")]
        public IActionResult BuyUrun(int id)
        {
            try
            {
                return Ok(siparisService.Buy(id));
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }
        }
    }
}
