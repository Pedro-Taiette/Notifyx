using Notifyx.Domain.Entities;
using Notifyx.Contracts;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Infrastructure.Channels;

internal class SmsSender : INotificationChannelSender
{
    public NotificationType Channel => NotificationType.Sms;

    public Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        Console.WriteLine(
            $"[SMS] Sending to user '{notification.UserId}' ------\n" +
            $"{notification.Title}\n" +
            $"{notification.Body}\n");

        notification.MarkAsSent();
        return Task.FromResult(true);
    }
}
