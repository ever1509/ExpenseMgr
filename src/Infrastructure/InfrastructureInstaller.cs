using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Infrastructure.Identity;
using Infrastructure.Persistance;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
             IConfiguration configuration)
        { 
            services.AddDbContext<ExpenseContext>(options =>            
                options.UseNpgsql(configuration.GetConnectionString("ExpenseDbConnection"),
                    b=>b.MigrationsAssembly(typeof(ExpenseContext).Assembly.FullName)));

            services.AddScoped<IExpenseContext>(provider => provider.GetService<ExpenseContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ExpenseContext>();

            var s3Settings = new S3Settings();
            configuration.Bind(nameof(s3Settings), s3Settings);
            services.AddSingleton(s3Settings);

            var mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomProfile(s3Settings));
            });

            var mapperCustomProfile = mapperCfg.CreateMapper();

            services.AddSingleton(mapperCustomProfile);
    
            services.AddTransient<IFileUploader, S3FileUploader>();

            return services;
        }
    }
}
