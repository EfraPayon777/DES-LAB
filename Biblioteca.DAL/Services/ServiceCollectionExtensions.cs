using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.DAL.Interfaces;
using Biblioteca.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IEditorialRepository, EditorialRepository>();
            services.AddTransient<ILibroRepository, LibroRepository>();
            return services;
        }
    }
}
