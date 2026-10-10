using CC230286_DESAFIO_03.BL.AutoMapper;
using CC230286_DESAFIO_03.BL.Interfaces;
using CC230286_DESAFIO_03.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CC230286_DESAFIO_03.BL.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceConnector(this IServiceCollection services)
    {
        services.AddAutoMapper(_ => { }, typeof(AutoMapperProfile));
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IProductoService, ProductoService>();
        services.AddScoped<IPedidoService, PedidoService>();
        return services;
    }
}
