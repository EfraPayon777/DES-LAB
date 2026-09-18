using Microsoft.EntityFrameworkCore;
using PedidosAPI.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PedidosDbContext>(options =>
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
// Generador automático de 1,500 pedidos
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PedidosDbContext>();
    if (!context.Pedidos.Any()) // Solo inserta si la tabla está vacía
    {
        for (int i = 1; i <= 1500; i++)
        {
            context.Pedidos.Add(new Pedido
            {
                Descripcion = "Pedido automatizado " + i,
                Total = 150.75m,
                ClienteId = i // Relaciona 1 pedido por cada cliente
            });
        }
        context.SaveChanges();
    }
}

app.Run();
