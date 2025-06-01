using Domain.Interfaces.Repository;
using Domain.Interfaces.UseCase.Veiculo;
using Domain.Interfaces.UseCase.Venda;
using Domain.UseCases.Venda;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Veiculo.API.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<IVendaUseCase, VendaUseCase>();
            services.AddScoped<IVeiculoUseCase, VeiculoUseCase>();

            services.AddDbContext<VeiculoVendaContext>(options =>
                options.UseNpgsql(connectionString));


            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            services.AddScoped<IVendaRepository, VendaRepository>();
            return services;
        }
    }
}
