using AutoMapper;
using CC230286_DESAFIO_03.BL.AutoMapper;
using CC230286_DESAFIO_03.BL.Services;
using CC230286_DESAFIO_03.Controllers;
using CC230286_DESAFIO_03.DAL.Repositories;
using CC230286_DESAFIO_03.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace CC230286_DESAFIO_03.Tests;

public class ProductosControllerTests
{
    [Fact]
    public async Task Post_CreaProducto_CuandoDatosSonValidos()
    {
        using var context = Setup.GetDatabaseContext();

        var config = new MapperConfiguration(
            cfg => cfg.AddProfile<AutoMapperProfile>(),
            NullLoggerFactory.Instance);

        var mapper = config.CreateMapper();

        var repository = new ProductoRepository(context);
        var service = new ProductoService(repository, mapper);
        var controller = new ProductosController(service);

        var nuevoProducto = new ProductoDto
        {
            Nombre = "Mouse Logitech",
            Descripcion = "Mouse USB",
            Precio = 25.50m,
            Stock = 10
        };

        var resultado = await controller.Post(nuevoProducto);

        var createdResult =
            Assert.IsType<CreatedAtActionResult>(resultado);

        var producto = Assert.IsType<ProductoDto>(
            createdResult.Value);

        Assert.True(producto.Id > 0);
        Assert.Equal("Mouse Logitech", producto.Nombre);
        Assert.Equal(25.50m, producto.Precio);
        Assert.Equal(10, producto.Stock);

        var guardado = await context.Productos.FindAsync(producto.Id);

        Assert.NotNull(guardado);
        Assert.Equal("Mouse Logitech", guardado.Nombre);
        Assert.Equal(25.50m, guardado.Precio);
        Assert.Equal(10, guardado.Stock);
    }
}