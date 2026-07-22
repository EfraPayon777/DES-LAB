using Microsoft.EntityFrameworkCore;
using MVCPeliculas.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PeliculasDbContext>(item =>
item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

using (var scope = app.Services.CreateScope()) { 
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HelloWorld}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "saludar",
    pattern: "{controller}/{action}/{nombre}/{apellido}/{numVeces?}");

app.Run();
