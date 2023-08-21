using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Abstract;
using Task.BLL.Concrete;
using Task.EntityLayer.DTOs;

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
                this.kullaniciService=kullaniciService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllKullanici")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(kullaniciService.GetAll());
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu");
            }

        }

        [HttpPost("AddKullanici")]
        public IActionResult Add(KullaniciDTO kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (kullaniciService.KullaniciExist(kullanici.TCKimlikNo))
                    {
                        return BadRequest("Aynı TC kimlik numarasına sahip bir kullanıcı bulunmaktadır.");
                    }
                    else
                    {
                        return Ok(kullaniciService.Add(kullanici));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
               

            }
            catch (Exception e)
            {

                return BadRequest("Bir hata oluştu.");
            }

        }

    }
}
