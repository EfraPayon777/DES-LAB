using CC230286_DESAFIO_03.DAL.Context;
using CC230286_DESAFIO_03.DAL.Interfaces;
using CC230286_DESAFIO_03.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CC230286_DESAFIO_03.DAL.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryConnector(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                options.UseSqlServer(connectionString);
            }
            else
            {
                options.UseInMemoryDatabase("Desafio03Db");
            }
        });

        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();

        return services;
    }
}
