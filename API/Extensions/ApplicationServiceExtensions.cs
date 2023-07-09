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
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(optionsAction =>
            {
                optionsAction.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            //services.AddDbContext<YourContextClassName>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();

            services.AddScoped<ITokenService, TokenServices>();
            return services;
        }
    }
}