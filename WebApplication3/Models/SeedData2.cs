using System;
using Microsoft.Extensions.DependencyInjection;

//https://dotnetthoughts.net/seed-database-in-aspnet-core/

namespace ElectronicsStore.Models
{
    public static class SeedData2
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ElectronicsStoreContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }
    }
}
