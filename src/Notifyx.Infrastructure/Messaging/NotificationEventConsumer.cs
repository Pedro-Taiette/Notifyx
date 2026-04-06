using Microsoft.Extensions.DependencyInjection;
using Notifyx.Contracts;
using Notifyx.Application.Interfaces;

namespace Notifyx.Infrastructure.Messaging;

public class NotificationEventConsumer(IServiceScopeFactory scopeFactory)
{
    public async Task ConsumeAsync(NotificationEvent notificationEvent, CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<INotificationService>();
        await service.SendNotificationAsync(notificationEvent, cancellationToken);
    }
}
