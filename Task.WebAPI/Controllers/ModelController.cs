using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Abstract;
using Task.EntityLayer.DTOs;

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService modelService;

        public ModelController(IModelService modelService)
        {
            this.modelService = modelService;
        }

        [HttpGet("GetAllModel")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(modelService.GetAll());
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }
           
        }

        [HttpPost("CreateModel")]
        [Authorize(Roles = "UrunEkleme")]
        public IActionResult Add(ModelDTO model)
        {
            try
            {
                
                return Ok(modelService.Add(model));
            }
            catch (Exception)
            {

                return BadRequest("Bir hata oluştu.");
            }
            
        }
    }
}
