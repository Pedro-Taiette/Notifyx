using Notifyx.Domain.Entities;
using Notifyx.Domain.Enums;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Infrastructure.Channels;

internal class InAppSender : INotificationChannelSender
{
    public NotificationType Channel => throw new NotImplementedException();

    public Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        Console.WriteLine(
            $"Notification '{notification.Id}' from '{notification.SourceService}' for '{notification.UserId}' ------\n" +
            $"{notification.Title}\n" +
            $"{notification.Body}\n");

        notification.MarkAsSent();
        notification.MarkAsRead();

        // will always succeed
        return Task.FromResult(true);
    }
}
