using System;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ElectronicsStore.Areas.Identity.IdentityHostingStartup))]
namespace ElectronicsStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ElectronicsStoreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ElectronicsStoreContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<ElectronicsStoreContext>();
            });
        }
    }
}