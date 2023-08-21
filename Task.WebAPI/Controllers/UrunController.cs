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
    public class UrunController : ControllerBase
    {
        private readonly IUrunService urunService;
        private readonly IKategoriService kategoriService;

        public UrunController(IUrunService urunService,IKategoriService kategoriService)
        {
            this.urunService = urunService;
            this.kategoriService = kategoriService;
        }

        [HttpGet("GetAllPublishedUrun")]
        public IActionResult GetAllByFilter()
        {
            try
            {
                return Ok(urunService.GetAllByFilter(x => x.YayindaMi==true));
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }

        [HttpPost("CreateUrun")]
        [Authorize(Roles = "UrunYayinlama")]
        public IActionResult Add(UrunDTO urun)
        {
            try
            {
                if (!kategoriService.KategoriExist(urun.KategoriId))
                {
                    return NotFound("Kategori bulunamadi.");
                }
                else
                {
                    return Ok(urunService.Add(urun));
                }
                
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }

        [HttpPut("UpdateUrun")]
        [Authorize(Roles = "UrunYayinlama")]
        public IActionResult Update(UrunDTO urun)
        {
            try
            {
                if (!urunService.UrunExist(urun.UrunId))
                {
                    return NotFound("Urun bulunamadi.");
                }
                else
                {
                    return Ok(urunService.Update(urun));
                }
                
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }

        [HttpPut("{urunId}")]
        [Authorize(Roles = "UrunYayinlama")]
        public IActionResult Publish(int urunId)
        {
            try
            {
                if (!urunService.UrunExist(urunId))
                {
                    return NotFound("Urun bulunamadi.");
                }
                else
                {
                    return Ok(urunService.Publish(urunId));
                }

            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }
        [HttpPut("{urunId}")]
        [Authorize(Roles = "UrunYayinlama")]
        public IActionResult Cancel(int urunId)
        {
            try
            {
                if (!urunService.UrunExist(urunId))
                {
                    return NotFound("Urun bulunamadi.");
                }
                else
                {
                    return Ok(urunService.Cancel(urunId));
                }

            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }

    }
}
