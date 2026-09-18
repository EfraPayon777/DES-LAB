using Microsoft.EntityFrameworkCore;

namespace PedidosAPI.Models
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
