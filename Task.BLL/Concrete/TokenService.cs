using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Abstract;
using Task.EntityLayer.DTOs;

namespace Task.BLL.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;

        public TokenService(IConfiguration config)
        {
            this.config = config;
        }
        public LoginResponseDTO GenerateToken(string rol)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["AppSettings:Secret"]));            

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: config["AppSettings:ValidIssuer"],
                    audience: config["AppSettings:ValidAudience"],
                    claims: new List<Claim> {
                    new Claim("rol", rol)
                    },

                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return (new LoginResponseDTO
            {
                Rol = rol,
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                
            });;


        }

        
    }
}
