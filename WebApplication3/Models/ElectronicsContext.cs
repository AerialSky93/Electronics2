using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Models
{
    public partial class ElectronicsContext : DbContext
    {
        public ElectronicsContext()
        {
        }

        public ElectronicsContext(DbContextOptions<ElectronicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {

                entity.Property(e => e.VendorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
