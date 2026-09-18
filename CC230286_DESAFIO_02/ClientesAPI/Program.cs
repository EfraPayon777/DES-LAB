using Microsoft.EntityFrameworkCore;
using ClientesAPI.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ClientesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ClientesDbContext>();
    if (!context.Clientes.Any()) // Solo inserta si la tabla está vacía
    {
        for (int i = 1; i <= 1500; i++)
        {
            context.Clientes.Add(new Cliente
            {
                Nombre = "Cliente " + i,
                Apellido = "Prueba",
                Email = $"cliente{i}@udb.edu.sv",
                Telefono = "7000-0000"
            });
        }
        context.SaveChanges();
    }
}
app.Run();
