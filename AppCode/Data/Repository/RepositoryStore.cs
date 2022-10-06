using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCode.Data.Repository
{
    public static class RepositoryStore
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => 
            { 
                options.UseSqlServer(Environment.GetEnvironmentVariable("APPCODEENV_ConnectionStrings__DbContext")); 
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;

        }
    }
}
