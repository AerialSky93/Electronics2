using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using ElectronicsStore.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicsStore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ElectronicsContext>();
                try
                {
                    SeedData.Initialize(services);
                    SeedData2.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                            .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .Build();
    }
}
