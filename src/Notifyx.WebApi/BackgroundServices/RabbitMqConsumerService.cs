using EasyNetQ;
using Notifyx.Contracts;
using Notifyx.Infrastructure.Messaging;

namespace Notifyx.WebApi.BackgroundServices;

public class RabbitMqConsumerService(IBus bus, NotificationEventConsumer consumer) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await bus.PubSub.SubscribeAsync<NotificationEvent>(
            subscriptionId: "notifyx",
            onMessage: msg => consumer.ConsumeAsync(msg, stoppingToken),
            cancellationToken: stoppingToken);
    }
}
