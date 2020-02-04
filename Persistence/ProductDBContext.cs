using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Persistence
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DeliveryPrice)
                    .HasColumnName("DeliveryPrice")
                    .HasColumnType("decimal(4, 2)");

            });

            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.ToTable("ProductOptions");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(23)
                    .IsUnicode(false);

            });
        }
    }
}
