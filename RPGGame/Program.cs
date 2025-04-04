using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RPGGame.Domain;
using RPGGame.Interfaces;
using RPGGame.Services;
using Serilog;

namespace RPGGame
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>{
                var exception = (Exception)args.ExceptionObject;
                Log.Fatal(exception, "Tətbiqdə tutulmamış xəta baş verdi!");
                Log.CloseAndFlush();
            };

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Log.Fatal(e.Exception, "Fire-and-forget və ya background Task xətası baş verdi.");
                e.SetObserved(); 
            };
            try
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

                          services.AddSingleton<ISelectingService, SelectingService>();
                      }
                    ).Build();


                await host.RunAsync();
            }
            catch (Exception ex) { Log.Fatal(ex, "Tətbiq gözlənilmədən dayandı!"); }
            finally { await Log.CloseAndFlushAsync(); }
        }
    }
}
