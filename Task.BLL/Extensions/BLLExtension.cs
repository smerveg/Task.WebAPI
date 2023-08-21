using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Abstract;
using Task.BLL.Concrete;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Task.BLL.Extensions
{
    public static class BLLExtension
    {
        public static IServiceCollection LoadBLLExtension(this IServiceCollection services,IConfiguration configuration) 
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddScoped<IKullaniciService, KullaniciService>();
            services.AddScoped<IKategoriService, KategoriService>();
            services.AddScoped<IMarkaService, MarkaService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IUrunService, UrunService>();
            services.AddScoped<ISiparisService, SiparisService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }
            ).AddJwtBearer(j =>
            {
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["AppSettings:ValidIssuer"],
                    ValidAudience = configuration["AppSettings:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    RoleClaimType = "rol"
                };


            });

            services.AddAuthorization();

            return services;
        }
    }
}
