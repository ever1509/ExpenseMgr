using API.Installers;
using Application;
using Infrastructure;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureContainer(ServiceRegistry services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowExpensesMgr",
                    builder => builder.WithOrigins("http://localhost:49602"));
            });
            services.AddJwtConfiguration(Configuration);

            services.AddSwaggerConfiguration(); 
            
            services.AddApplication();

            services.AddInfrastructure(Configuration);
            
            services.AddControllers();
           
            // Also exposes Lamar specific registrations
            // and functionality
            services.Scan(s =>
            {
                s.AssembliesAndExecutablesFromApplicationBaseDirectory(a=>a.FullName.Contains("Application"));
                s.AssembliesAndExecutablesFromApplicationBaseDirectory(a=>a.FullName.Contains("Infrastructure"));
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.SingleImplementationsOfInterface();
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowExpensesMgr");

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/ExpensesMgrAPI/swagger.json", "Expenses Manager API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
