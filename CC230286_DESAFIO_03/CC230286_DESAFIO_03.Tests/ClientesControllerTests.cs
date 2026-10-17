using AutoMapper;
using CC230286_DESAFIO_03.BL.AutoMapper;
using CC230286_DESAFIO_03.BL.Services;
using CC230286_DESAFIO_03.Controllers;
using CC230286_DESAFIO_03.DAL.Repositories;
using CC230286_DESAFIO_03.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CC230286_DESAFIO_03.Tests;

public class ClientesControllerTests
{
    [Fact]
    public async Task Post_CreaCliente_CuandoDatosSonValidos()
    {
        using var context = Setup.GetDatabaseContext();

        var config = new MapperConfiguration(
            cfg => cfg.AddProfile<AutoMapperProfile>(),
            NullLoggerFactory.Instance);

        var mapper = config.CreateMapper();

        var repository = new ClienteRepository(context);
        var service = new ClienteService(repository, mapper);
        var controller = new ClientesController(service);

        var nuevoCliente = new ClienteDto
        {
            Nombre = "Juan",
            Apellido = "Perez",
            Email = "juan@example.com"
        };

        var resultado = await controller.Post(nuevoCliente);

        var createdResult =
            Assert.IsType<CreatedAtActionResult>(resultado);

        var cliente = Assert.IsType<ClienteDto>(
            createdResult.Value);

        Assert.True(cliente.Id > 0);
        Assert.Equal("Juan", cliente.Nombre);
        Assert.Equal("Perez", cliente.Apellido);

        var guardado = await context.Clientes.FindAsync(cliente.Id);
        Assert.NotNull(guardado);
    }


    [Fact]
    public async Task Post_RechazaCliente_CuandoDatosSonInvalidos()
    {
        using var context = Setup.GetDatabaseContext();

        var config = new MapperConfiguration(
            cfg => cfg.AddProfile<AutoMapperProfile>(),
            NullLoggerFactory.Instance);

        var mapper = config.CreateMapper();

        var repository = new ClienteRepository(context);
        var service = new ClienteService(repository, mapper);
        var controller = new ClientesController(service);

        var clienteInvalido = new ClienteDto
        {
            Nombre = "",
            Apellido = "Perez",
            Email = "correo-invalido"
        };

        // Validar las Data Annotations
        var errores = new List<ValidationResult>();

        var esValido = Validator.TryValidateObject(
            clienteInvalido,
            new ValidationContext(clienteInvalido),
            errores,
            validateAllProperties: true);

        Assert.False(esValido);

        foreach (var error in errores)
        {
            foreach (var campo in error.MemberNames)
            {
                controller.ModelState.AddModelError(
                    campo,
                    error.ErrorMessage ?? "Dato inválido");
            }
        }

        var cantidadAntes = context.Clientes.Count();

        var resultado = await controller.Post(clienteInvalido);
        // Assert
        Assert.IsType<BadRequestObjectResult>(resultado);

        Assert.Equal(cantidadAntes, context.Clientes.Count());
    }
}