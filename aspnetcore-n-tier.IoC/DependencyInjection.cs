using aspnetcore_n_tier.BLL.Services;
using aspnetcore_n_tier.BLL.Services.IServices;
using aspnetcore_n_tier.DAL.DataContext;
using aspnetcore_n_tier.DAL.Repositories;
using aspnetcore_n_tier.DAL.Repositories.IRepositories;
using aspnetcore_n_tier.Utility.Utilities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetcore_n_tier.IoC
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AspNetCoreNTierDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
