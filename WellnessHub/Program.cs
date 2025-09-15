using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WellnessHub.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    // No forzamos camelCase: usamos exactamente los JsonPropertyName que definimos.
    opts.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WellnessHub API - Comidas", Version = "v1" });
});

// Configure DB context (usa tu cadena en appsettings.json)
builder.Services.AddDbContext<WellnessHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();