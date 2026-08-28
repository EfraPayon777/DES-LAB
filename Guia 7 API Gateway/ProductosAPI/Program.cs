using Microsoft.EntityFrameworkCore;
using ProductosAPI.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductosDbContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));

// INICIO -> CONFIGURACION DE REDIS 

builder.Services.AddStackExchangeRedisOutputCache(options =>
{
    options.Configuration =
builder.Configuration.GetConnectionString("RedisConnection");
});

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration =
ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisConnection")!, true); 
    configuration.ConnectTimeout = 5000;
    configuration.SyncTimeout = 5000;
    configuration.AbortOnConnectFail = false;
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddOutputCache();

// FIN -> CONFIGURACION DE REDIS 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseOutputCache(); // <- NUEVO  

app.UseAuthorization();

app.MapControllers();

app.Run();
