using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Abstract;
using Task.EntityLayer.DTOs;

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            this.kategoriService = kategoriService;
        }

        
        [HttpGet("GetAllKategori")]
        public IActionResult GetAll()
        {
            try
            {
                return  Ok(kategoriService.GetAll());
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu");
            }
           
        }

        [HttpPost("CreateKategori")]
        [Authorize(Roles = "UrunEkleme")]
        public IActionResult Add(KategoriDTO kategori)
        {
            try
            {
                return Ok(kategoriService.Add(kategori));
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu");
            }
           
        }
    }
}
