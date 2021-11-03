using FruitApi.Repositories.Fruits;
using FruitApi.Services.Fruits;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FruitApi.Configuration
{
    public class DependencyInjectionConfiguration
    {
        public static void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IFruitService, FruitService>();
            serviceCollection.AddScoped<IFruitRepository, FruitRepository>();
        }
    }
}