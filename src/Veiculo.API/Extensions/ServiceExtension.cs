using Veiculo.Domain.Interfaces.Service;
using Veiculo.Infrastructure.Service;

namespace Veiculo.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["pagamentoAPI:baseUrl"];

            services.AddScoped<IPagamentoService>(provider =>
                              new PagamentoService(baseUrl));

            return services;
        }
    }
}