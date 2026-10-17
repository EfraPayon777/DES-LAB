using AutoMapper;
using CC230286_DESAFIO_03.BL.AutoMapper;
using CC230286_DESAFIO_03.BL.Services;
using CC230286_DESAFIO_03.Controllers;
using CC230286_DESAFIO_03.DAL.Context;
using CC230286_DESAFIO_03.DAL.Repositories;
using CC230286_DESAFIO_03.Entities.Dtos;
using CC230286_DESAFIO_03.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace CC230286_DESAFIO_03.Tests;

public class PedidosControllerTests
{
    private static PedidosController CrearControlador(
        ApplicationDbContext context)
    {
        var config = new MapperConfiguration(
            cfg => cfg.AddProfile<AutoMapperProfile>(),
            NullLoggerFactory.Instance);

        var mapper = config.CreateMapper();

        var pedidoRepository = new PedidoRepository(context);
        var clienteRepository = new ClienteRepository(context);
        var productoRepository = new ProductoRepository(context);

        var service = new PedidoService(
            pedidoRepository,
            clienteRepository,
            productoRepository,
            mapper);

        return new PedidosController(service);
    }

    [Fact]
    public async Task Post_CreaPedido_CuandoDatosSonValidos()
    {
        using var context = Setup.GetDatabaseContext();

        var cliente = new Cliente
        {
            Nombre = "Carlos",
            Apellido = "Lopez",
            Email = "carlos.prueba@example.com"
        };

        var producto = new Producto
        {
            Nombre = "Teclado",
            Descripcion = "Teclado mecanico",
            Precio = 50.00m,
            Stock = 10
        };

        context.Clientes.Add(cliente);
        context.Productos.Add(producto);
        await context.SaveChangesAsync();

        var controller = CrearControlador(context);

        var nuevoPedido = new PedidoDto
        {
            ClienteId = cliente.Id,
            ProductoId = producto.Id,
            Cantidad = 3
        };

        var resultado = await controller.Post(nuevoPedido);

        var createdResult =
            Assert.IsType<CreatedAtActionResult>(resultado);

        var pedido = Assert.IsType<PedidoDto>(
            createdResult.Value);

        Assert.True(pedido.Id > 0);
        Assert.Equal(cliente.Id, pedido.ClienteId);
        Assert.Equal(producto.Id, pedido.ProductoId);
        Assert.Equal(3, pedido.Cantidad);

        var guardado = await context.Pedidos.FindAsync(pedido.Id);

        Assert.NotNull(guardado);
        Assert.Equal(3, guardado.Cantidad);

        var productoActualizado =
            await context.Productos.FindAsync(producto.Id);

        Assert.NotNull(productoActualizado);
        Assert.Equal(7, productoActualizado.Stock);
    }

    [Fact]
    public async Task Get_ConsultaPedido_CuandoExiste()
    {
        using var context = Setup.GetDatabaseContext();

        var controller = CrearControlador(context);

        var pedidoExistente = context.Pedidos.First();

        var resultado = await controller.GetById(pedidoExistente.Id);

        var okResult = Assert.IsType<OkObjectResult>(resultado);

        var pedido = Assert.IsType<PedidoDto>(okResult.Value);

        Assert.Equal(pedidoExistente.Id, pedido.Id);
        Assert.Equal(pedidoExistente.ClienteId, pedido.ClienteId);
        Assert.Equal(pedidoExistente.ProductoId, pedido.ProductoId);
        Assert.Equal(pedidoExistente.Cantidad, pedido.Cantidad);
    }

    [Fact]
    public async Task Get_RetornaNotFound_CuandoPedidoNoExiste()
    {
        using var context = Setup.GetDatabaseContext();

        var controller = CrearControlador(context);

        var resultado = await controller.GetById(999999);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task Post_RechazaPedido_CuandoStockEsInsuficiente()
    {
        using var context = Setup.GetDatabaseContext();

        var cliente = new Cliente
        {
            Nombre = "Ana",
            Apellido = "Martinez",
            Email = "ana.prueba@example.com"
        };

        var producto = new Producto
        {
            Nombre = "Monitor",
            Descripcion = "Monitor LED",
            Precio = 150.00m,
            Stock = 2
        };

        context.Clientes.Add(cliente);
        context.Productos.Add(producto);
        await context.SaveChangesAsync();

        var controller = CrearControlador(context);

        var pedidoInvalido = new PedidoDto
        {
            ClienteId = cliente.Id,
            ProductoId = producto.Id,
            Cantidad = 10
        };

        var cantidadInicial = context.Pedidos.Count();

        var resultado = await controller.Post(pedidoInvalido);

        Assert.IsType<BadRequestObjectResult>(resultado);

        Assert.Equal(cantidadInicial, context.Pedidos.Count());

        var productoActualizado =
            await context.Productos.FindAsync(producto.Id);

        Assert.NotNull(productoActualizado);
        Assert.Equal(2, productoActualizado.Stock);
    }
}