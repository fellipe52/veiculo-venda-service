using Application;
using Application.Interfaces;
using Domain.Notification;
using Veiculo.Application;

namespace Veiculo.API.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IVeiculoApplication, VeiculoApplication>();
            services.AddScoped<IVendaApplication, VendaApplication>();

            services.AddScoped<NotificationContext>();

            return services;
        }
    }
}
