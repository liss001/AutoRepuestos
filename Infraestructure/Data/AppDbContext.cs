using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Producto> producto { get; set; }
        public DbSet<Venta> venta { get; set; }
        public DbSet<VentaItem> ventaItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Venta>()
                .Property(v => v.Total)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<VentaItem>()
                .Property(v => v.PrecioUnitario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<VentaItem>()
                .Property(v => v.SubTotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
