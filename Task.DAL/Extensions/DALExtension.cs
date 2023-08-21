using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Repositories.Abstract;
using Task.DAL.Repositories.Concrete;
using Task.DAL.UnitOfWorks;

namespace Task.DAL.Extensions
{
    public static  class DALExtension
    {
        public static IServiceCollection LoadDALExtension(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return services;
        }
    }
}
