using Notifyx.Domain.Entities;
using Notifyx.Domain.Enums;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Infrastructure.Channels;

internal class EmailSender : INotificationChannelSender
{
    public NotificationType Channel => NotificationType.Email;

    public Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
