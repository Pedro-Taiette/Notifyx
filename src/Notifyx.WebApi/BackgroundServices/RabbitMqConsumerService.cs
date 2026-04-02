using Notifyx.Infrastructure.Messaging;

namespace Notifyx.WebApi.BackgroundServices;

public class RabbitMqConsumerService(NotificationEventConsumer consumer) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
