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
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }

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

            modelBuilder.Entity<Supplier>(entity =>
            {

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
