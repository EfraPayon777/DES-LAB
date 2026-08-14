using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.BL.AutoMapper;
using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CC230396_Desafio01.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(_ => { }, typeof(AutoMapperProfile));

            // Servicios
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ILibroService, LibroService>();

            // Repositorios DAL
            services.AddRepositoryConnector();
            return services;
        }
    }
}