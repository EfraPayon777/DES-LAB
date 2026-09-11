using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AUTENTICACION_Y_AUTORIZACION_EN_.NET.Models;

namespace AUTENTICACION_Y_AUTORIZACION_EN_.NET.Data
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<Usuario>(options)
    {
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // MARCAS
            // =========================
            modelBuilder.Entity<Marca>().HasData(
                new Marca
                {
                    Id = 1,
                    Nombre = "Toyota"
                },
                new Marca
                {
                    Id = 2,
                    Nombre = "Honda"
                },
                new Marca
                {
                    Id = 3,
                    Nombre = "Ford"
                },
                new Marca
                {
                    Id = 4,
                    Nombre = "Chevrolet"
                }
            );

            // =========================
            // MODELOS
            // =========================
            modelBuilder.Entity<Modelo>().HasData(
                new Modelo
                {
                    Id = 1,
                    MarcaId = 1,
                    Nombre = "Corolla"
                },
                new Modelo
                {
                    Id = 2,
                    MarcaId = 1,
                    Nombre = "Hilux"
                },
                new Modelo
                {
                    Id = 3,
                    MarcaId = 2,
                    Nombre = "Civic"
                },
                new Modelo
                {
                    Id = 4,
                    MarcaId = 2,
                    Nombre = "CR-V"
                },
                new Modelo
                {
                    Id = 5,
                    MarcaId = 3,
                    Nombre = "Mustang"
                },
                new Modelo
                {
                    Id = 6,
                    MarcaId = 3,
                    Nombre = "Ranger"
                },
                new Modelo
                {
                    Id = 7,
                    MarcaId = 4,
                    Nombre = "Camaro"
                },
                new Modelo
                {
                    Id = 8,
                    MarcaId = 4,
                    Nombre = "Silverado"
                }
            );

            // =========================
            // VEHÍCULOS
            // =========================
            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo
                {
                    Id = 1,
                    ModeloId = 1,
                    Anio = 2020
                },
                new Vehiculo
                {
                    Id = 2,
                    ModeloId = 1,
                    Anio = 2022
                },
                new Vehiculo
                {
                    Id = 3,
                    ModeloId = 2,
                    Anio = 2021
                },
                new Vehiculo
                {
                    Id = 4,
                    ModeloId = 3,
                    Anio = 2019
                },
                new Vehiculo
                {
                    Id = 5,
                    ModeloId = 3,
                    Anio = 2023
                },
                new Vehiculo
                {
                    Id = 6,
                    ModeloId = 4,
                    Anio = 2022
                },
                new Vehiculo
                {
                    Id = 7,
                    ModeloId = 5,
                    Anio = 2021
                },
                new Vehiculo
                {
                    Id = 8,
                    ModeloId = 6,
                    Anio = 2020
                },
                new Vehiculo
                {
                    Id = 9,
                    ModeloId = 7,
                    Anio = 2018
                },
                new Vehiculo
                {
                    Id = 10,
                    ModeloId = 8,
                    Anio = 2023
                }
            );
        }
    }
}
