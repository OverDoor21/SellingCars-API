using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExt
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
         IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => 
            { 
             opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();
            //Added scoped for all depedency enjection in code
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ILotRepository, LotRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}