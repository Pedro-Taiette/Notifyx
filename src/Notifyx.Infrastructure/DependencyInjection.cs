using EasyNetQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifyx.Domain.Interfaces;
using Notifyx.Infrastructure.Channels;
using Notifyx.Infrastructure.Messaging;
using Notifyx.Infrastructure.Persistence;
using Notifyx.Infrastructure.Persistence.Repository;

namespace Notifyx.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NotificationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<INotificationRepository, NotificationRepository>();

        services.AddEasyNetQ(configuration["RabbitMQ"]!);

        services.AddSingleton<NotificationEventConsumer>();

        services.AddScoped<EmailSender>();
        services.AddScoped<SmsSender>();
        services.AddScoped<InAppSender>();
        services.AddScoped<INotificationChannelSender>(sp => sp.GetRequiredService<EmailSender>());
        services.AddScoped<INotificationChannelSender>(sp => sp.GetRequiredService<SmsSender>());
        services.AddScoped<INotificationChannelSender>(sp => sp.GetRequiredService<InAppSender>());
        services.AddScoped<INotificationChannelSender, AllSender>();

        return services;
    }
}
