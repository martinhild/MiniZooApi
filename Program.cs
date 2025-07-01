using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MiniZooApi.Data;

namespace MiniZooApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        // Swagger-Konfiguration
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MiniZoo API",
                Version = "v1",
                Description = "API zur Verwaltung von Tieren im MiniZoo"
            });
        });

        // ✅ DbContext-Registrierung (wichtig für EF Core)
        builder.Services.AddDbContext<ZooDbContext>(options =>
            options.UseSqlite("Data Source=MiniZoo.db"));

        var app = builder.Build();

        app.UseCors();

        // Swagger aktivieren
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniZoo API v1");
            c.RoutePrefix = string.Empty; // Swagger direkt unter /
        });

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
