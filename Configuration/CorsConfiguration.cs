using Microsoft.Extensions.DependencyInjection;

namespace FruitApi.Configuration
{
    public static class CorsConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularCliOrigin",
                    policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                );
            });
        }
    }
}