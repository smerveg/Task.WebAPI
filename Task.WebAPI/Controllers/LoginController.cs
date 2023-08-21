using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Abstract;
using Task.EntityLayer.DTOs;

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly ITokenService tokenService;

        public LoginController(IAuthService authService,ITokenService tokenService)
        {
            this.authService = authService;
            this.tokenService = tokenService;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDTO loginRequestDTO)
        {
            var result = authService.Login(loginRequestDTO);
            var s = (tokenService.GenerateToken(result));
            return Ok(s);
        }
    }
}
