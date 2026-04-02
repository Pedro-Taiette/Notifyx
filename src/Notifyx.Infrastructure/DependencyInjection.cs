using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifyx.Domain.Interfaces;
using Notifyx.Infrastructure.Messaging;
using Notifyx.Infrastructure.Persistence.Repository;

namespace Notifyx.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<NotificationDBContext>(options =>
        //    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<INotificationRepository, NotificationRepository>();

        // EasyNetQ configuration

        services.AddSingleton<NotificationEventConsumer>();

        // Add Channels

        return services;
    }
}
