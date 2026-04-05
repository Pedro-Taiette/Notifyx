using Notifyx.Domain.Entities;
using Notifyx.Domain.Enums;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Infrastructure.Channels;

internal class SmsSender : INotificationChannelSender
{
    public NotificationType Channel => NotificationType.Sms;

    public Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
