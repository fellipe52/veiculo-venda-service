using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Veiculo.API.Extensions;
using Infrastructure.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Config EF Core com PostgreSQL
builder.Services.AddDbContext<VeiculoVendaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependências da Application/Infrastructure
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();     
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    // Para o VeiculoVendaContext
    var VeiculoVendaContext = scope.ServiceProvider.GetRequiredService<VeiculoVendaContext>();
    try
    {
        // Aplica as migrações para o VeiculoVendaContext
        VeiculoVendaContext.Database.Migrate();
        Console.WriteLine("Migrações aplicadas para o VeiculoVendaContext.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao aplicar migrações para VeiculoVendaContext: {ex.Message}");
    }
}


app.Run();
