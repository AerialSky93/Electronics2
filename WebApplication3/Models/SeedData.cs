using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Models;
using X.PagedList;

//https://dotnetthoughts.net/seed-database-in-aspnet-core/

namespace WebApplication3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ElectronicsContext>();
            context.Database.EnsureCreated();
            if (!context.Product.Any())
            {
                context.Product.AddRange(
                 new Product
                 {
                     ProductName = "Samsung T3 Portable SSD - 500GB",
                     ProductDescription = "Superfast Read-Write Speeds of up to 450 MB/s; Shock Resistant & Secure Encryption"
                 },
                 new Product
                 {
                     ProductName = "Acer R240HY bidx 23.8-Inch IPS HDMI DVI VGA (1920 x 1080) Widescreen Monitor",
                     ProductDescription = "The Acer R240HY 23.8” IPS display shows every detail clearly and vivid without color difference from any viewing angle. Its zero frame design puts no boundary on your visual enjoyment while the brushed hairline finish stand matches any environment. It also supports VGA, DVI & HDMI inputs so you can easily power and extend the enjoyment from your smartphone or tablet on Full HD display."
                 },
                 new Product
                 {
                     ProductName = "Panasonic On-Ear Stereo Headphones RP-HT21 ",
                     ProductDescription = "Lightweight, open-air design on-ear headphones weigh just 1.2 oz. (without cable). Connectivity Technology: Wired;30mm large neodymium drivers deliver rich powerful bass and natural treble."
                 });
                 context.SaveChanges();
            }
        }
    }
}
