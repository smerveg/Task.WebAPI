using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Abstract;
using Task.EntityLayer.DTOs;

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : ControllerBase
    {
        private readonly IMarkaService markaService;

        public MarkaController(IMarkaService markaService)
        {
            this.markaService = markaService;
        }

        [HttpGet("GetAllMarka")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(markaService.GetAll());
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }
            
        }

        [HttpPost("CreateMarka")]
        [Authorize(Roles = "UrunEkleme")]
        public IActionResult Add(MarkaDTO marka)
        {
            try
            {
               
                return Ok(markaService.Add(marka));
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }
            
        }
    }
}
