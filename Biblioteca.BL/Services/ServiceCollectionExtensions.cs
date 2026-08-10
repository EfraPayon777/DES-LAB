using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.BL.AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.BL.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceConnector(this IServiceCollection services)
    {
        services.AddAutoMapper(_ => { }, typeof(AutoMapperProfile));
        services.AddTransient<IAutorService, AutorService>();
        services.AddTransient<IEditorialService, EditorialService>();
        services.AddTransient<ILibroService, LibroService>();
        services.AddRepositoryConnector();
        return services;
    }
}
