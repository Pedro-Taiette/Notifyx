using Microsoft.Extensions.DependencyInjection;
using Notifyx.Application.Interfaces;
using Notifyx.Application.Services;

namespace Notifyx.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, NotificationService>();
        return services;
    }
}
