using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RPGGame.Domain;
using Serilog;

namespace RPGGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", false, false);
                })
                .UseSerilog((context, config) =>
                {
                    config.ReadFrom.Configuration(context.Configuration);
                })
                .ConfigureServices((context, services) =>
                  {
                      var configuration = context.Configuration;

                      services.AddDbContext<RPGDbContext>(options =>
                      {
                          options.UseSqlServer(configuration.GetConnectionString("RPG")); 
                      });

                      services.AddLogging();
          
                  }
                ).Build();


            host.Run();
            
        }
    }
}
