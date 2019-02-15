﻿using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

//https://dotnetthoughts.net/seed-database-in-aspnet-core/

namespace ElectronicsStore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ElectronicsContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Vendor.Any())
            {
                context.ProductCategory.AddRange(
                 new ProductCategory
                 {
                     ProductCategoryName = "TV",
                 },
                 new ProductCategory
                 {
                     ProductCategoryName = "Computer Drive"
                 },
                new ProductCategory
                 {
                     ProductCategoryName = "Headphones",
                 });
                context.SaveChanges();
            }


            if (!context.Product.Any())
            {
                context.Product.AddRange(
                 new Product
                 {
                     ProductName = "Samsung T3 Portable SSD - 500GB",
                     ProductDescription = "Superfast Read-Write Speeds of up to 450 MB/s; Shock Resistant & Secure Encryption",
                     UnitPrice = 5.50F,
                     ImageLocation = "Product1.jpg"
                 },
                 new Product
                 {
                     ProductName = "Acer R240HY bidx 23.8-Inch IPS HDMI DVI VGA (1920 x 1080) Widescreen Monitor",
                     ProductDescription = "The Acer R240HY 23.8” IPS display shows every detail clearly and vivid without color difference from any viewing angle. Its zero frame design puts no boundary on your visual enjoyment while the brushed hairline finish stand matches any environment. It also supports VGA, DVI & HDMI inputs so you can easily power and extend the enjoyment from your smartphone or tablet on Full HD display.",
                     UnitPrice = 4.20F,
                     ImageLocation = "Product2.jpg"
                 },
                 new Product
                 {
                     ProductName = "Panasonic On-Ear Stereo Headphones RP-HT21 ",
                     ProductDescription = "Lightweight, open-air design on-ear headphones weigh just 1.2 oz. (without cable). Connectivity Technology: Wired;30mm large neodymium drivers deliver rich powerful bass and natural treble.",
                     UnitPrice = 9.80F,
                     ImageLocation = "Product3.jpg"
                 },
                new Product
                {
                    ProductName = "Canon TS8220 Wireless All in One Photo Printer, Black",
                    ProductDescription = "Introducing the sleek and streamlined PIXMA TS8220 Wireless Inkjet All-In-One home printer, available in Black, White and Red color options. The PIXMA TS8220 is a high-end Inkjet All-In-One printer designed with fast prints, robust features and lots of connectivity options in mind. ",
                    UnitPrice = 1.4F,
                    ImageLocation = "Product4.jpg"
                });
                context.SaveChanges();
            }

            if (!context.Vendor.Any())
            {
                context.Vendor.AddRange(
                 new Vendor
                 {
                     VendorName = "ABC Marketing",
                 },
                 new Vendor
                 {
                     VendorName = "GT Warehouse"
                 });
                context.SaveChanges();
            }
        }
    }
}
