using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.DAL.Interfaces;
using CC230396_Desafio01.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CC230396_Desafio01.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ILibroRepository, LibroRepository>();
            return services;
        }
    }
}