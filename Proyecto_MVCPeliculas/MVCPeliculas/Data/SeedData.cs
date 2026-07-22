using Microsoft.EntityFrameworkCore;
using MVCPeliculas.Models;

namespace MVCPeliculas.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeliculasDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PeliculasDbContext>>()))
            {
                // Busca si ya existen géneros y películas en la base de datos
                if (context.Generos.Any() && context.Peliculas.Any())
                {
                    return;  // DB ha sido inicializada
                }

                context.Generos.AddRange(
                    new Genero { Nombre = "Fantasía" },
                    new Genero { Nombre = "Drama" },
                    new Genero { Nombre = "Aventura" }
                );

                context.Peliculas.AddRange(
                    new Pelicula
                    {
                        Titulo = "Harry Potter y la piedra filosofal",
                        FechaLanzamiento = DateTime.Parse("2001-11-16"),
                        GeneroId = 1,
                        Precio = 7.55m,
                        Director = "Chris Columnbus"
                    },
                    new Pelicula
                    {
                        Titulo = "El Señor de los Anillos: la Comunidad del Anillo",
                        FechaLanzamiento = DateTime.Parse("2001-12-10"),
                        GeneroId = 3,
                        Precio = 8.30m,
                        Director = "Peter Jackson"
                    },
                    new Pelicula
                    {
                        Titulo = "El silencio de los corderos",
                        FechaLanzamiento = DateTime.Parse("1991-02-14"),
                        GeneroId = 2,
                        Precio = 6.25m,
                        Director = "Jonathan Demme"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
