using System;
using FruitApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FruitApi.Configuration.Database;
namespace FruitApi.Configuration
{
    public class DbContextConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var sqlServerConnectionString = configuration.GetConnectionString("FRUIT");
            if (sqlServerConnectionString == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SQLCONNSTR_FRUIT environment variable not found.");
                Console.WriteLine(
                    "Connection string format example: Server=localhost;Database=MyDB;user id=sa;password=MyPassword;");
                Console.ResetColor();
                throw new Exception("Connection string for db not set");
            }

            services.AddDbContextPool<FruitContext>(options =>
            {
                options.EnableThreadSafetyChecks(false);
                options.UseSqlServer(sqlServerConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(90));
            });

            services.AddTransient<IDatabaseConnectionFactory>(e =>
                new DatabaseConnectionFactory(sqlServerConnectionString));
        }
    }
}