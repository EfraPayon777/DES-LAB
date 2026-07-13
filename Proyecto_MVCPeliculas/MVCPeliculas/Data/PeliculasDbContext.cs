using Microsoft.EntityFrameworkCore;
using MVCPeliculas.Models;
namespace MVCPeliculas.Data;


public class PeliculasDbContext : DbContext
{
    public PeliculasDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Pelicula> Peliculas { get; set; }
    public DbSet<Genero> Generos { get; set; } // <- Nuevo modelo 
}
