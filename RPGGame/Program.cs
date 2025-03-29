using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RPGGame.Domain;


namespace RPGGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsetting.json", false, false);
                })
                .ConfigureServices((context, services) =>
                  {
                      var configuration = context.Configuration;

                      services.AddDbContext<RPGDbContext>(options =>
                      {
                          options.UseSqlServer(configuration.GetConnectionString("RPG")); 
                      });

                      services.AddLogging(logging =>
                      {
                          logging.ClearProviders();
                          logging.AddConsole();
                          logging.SetMinimumLevel(LogLevel.Information);

                          logging.AddFilter("Microsoft", LogLevel.Warning);
                          logging.AddFilter("System", LogLevel.Error);
                      });
          
                  }
                ).Build();

        }
    }
}
