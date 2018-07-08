using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
