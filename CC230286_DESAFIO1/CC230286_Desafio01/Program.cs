using CC230396_Desafio01.BL.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar los controladores
builder.Services.AddControllersWithViews();

// 1. Configurar Swagger (Servicios)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar nuestra cadena de conexión y las capas BL/DAL
builder.Services.Configure<CC230396_Desafio01.Common.AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddServiceConnector();

var app = builder.Build();

// 2. Activar la interfaz gráfica de Swagger solo en Desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();