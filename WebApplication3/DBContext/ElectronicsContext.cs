using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;

namespace ElectronicsStore.Models
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
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<VendorSupply> VendorSupply { get; set; }

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


                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {

                entity.Property(e => e.VendorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine)
                    .HasMaxLength(255)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(55)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(3)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsRequired()
                    .IsUnicode(false);

            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ProductCategoryDescription)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<VendorSupply>(entity =>
            {

            });

        }

        public DbSet<SportsStore.Models.Order> Order { get; set; }
    }
}
