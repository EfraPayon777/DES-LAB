using Microsoft.EntityFrameworkCore;
using PersonaApp.Models;

namespace Persona.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PersonaApp.Models.Persona> Personas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonaApp.Models.Persona>().HasKey(p => p.DUI);
        }
    }
}
