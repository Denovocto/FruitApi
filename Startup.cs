using System;
using FruitApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FruitApi
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DbContextConfiguration.Configure(services, _configuration);
            services.AddHttpsRedirection(options => options.HttpsPort = 443);
            services.AddControllers();
            CorsConfiguration.Configure(services);
            services.AddMemoryCache();
            services.AddResponseCompression(options => { options.EnableForHttps = true; }); 
            
            DependencyInjectionConfiguration.Configure(services, _configuration);
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment() && !webHostEnvironment.IsProduction()) return;
            applicationBuilder.UseCors("AllowAngularCliOrigin");
            applicationBuilder.UseResponseCompression();
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();
            applicationBuilder.UseEndpoints(endpoints => { endpoints.MapControllers().RequireAuthorization(); });
            applicationBuilder.UseSpa(_ => { });
        }
        
    }
}