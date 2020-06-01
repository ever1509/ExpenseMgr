using Application.Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistance;
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

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ExpenseContext>();



            return services;
        }
    }
}
