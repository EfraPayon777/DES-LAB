using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Models
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}