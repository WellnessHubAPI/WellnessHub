using Microsoft.EntityFrameworkCore;
//using WellnessHubApi.Data; 
using Microsoft.OpenApi.Models;
using WellnessHub.Data;


var builder = WebApplication.CreateBuilder(args);

// ===== Configurar DbContext con SQL Server =====
builder.Services.AddDbContext<WellnessHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===== Agregar servicios de controllers =====
builder.Services.AddControllers();

// ===== Swagger para documentación =====
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===== Aplicar migraciones automáticas =====
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WellnessHubContext>();
    db.Database.Migrate();
}

// ===== Middleware =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();