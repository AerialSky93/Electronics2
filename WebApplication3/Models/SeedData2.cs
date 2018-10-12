using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElectronicsStore.Models;
using X.PagedList;

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
