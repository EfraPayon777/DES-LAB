using CC230286_DESAFIO_03.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CC230286_DESAFIO_03.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Apellido).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Email).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            entity.Property(p => p.Descripcion).HasMaxLength(500);
            entity.Property(p => p.Precio).HasPrecision(18, 2).IsRequired();
            entity.Property(p => p.Stock).IsRequired();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.FechaPedido).IsRequired();
            entity.Property(p => p.Cantidad).IsRequired();

            entity.HasOne(p => p.Cliente)
                  .WithMany(c => c.Pedidos)
                  .HasForeignKey(p => p.ClienteId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Producto)
                  .WithMany(p => p.Pedidos)
                  .HasForeignKey(p => p.ProductoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Seed data inicial
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente { Id = 1, Nombre = "Carlos", Apellido = "Martinez", Email = "carlos.martinez@example.com" },
            new Cliente { Id = 2, Nombre = "Ana", Apellido = "Lopez", Email = "ana.lopez@example.com" },
            new Cliente { Id = 3, Nombre = "David", Apellido = "Hernandez", Email = "david.hernandez@example.com" }
        );

        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Laptop Dell Inspiron", Descripcion = "Core i7 16GB RAM SSD 512GB", Precio = 899.99m, Stock = 15 },
            new Producto { Id = 2, Nombre = "Mouse Inalámbrico Logitech", Descripcion = "Mouse ergonómico receptor USB", Precio = 24.50m, Stock = 50 },
            new Producto { Id = 3, Nombre = "Teclado Mecánico RGB", Descripcion = "Teclado switches Red con iluminación", Precio = 65.00m, Stock = 30 },
            new Producto { Id = 4, Nombre = "Monitor 24 Pulgadas Full HD", Descripcion = "Panel IPS 75Hz HDMI/VGA", Precio = 145.00m, Stock = 20 }
        );

        modelBuilder.Entity<Pedido>().HasData(
            new Pedido { Id = 1, FechaPedido = new DateTime(2026, 10, 1, 10, 0, 0, DateTimeKind.Utc), Cantidad = 1, ClienteId = 1, ProductoId = 1 },
            new Pedido { Id = 2, FechaPedido = new DateTime(2026, 10, 2, 14, 30, 0, DateTimeKind.Utc), Cantidad = 2, ClienteId = 2, ProductoId = 2 }
        );
    }
}
