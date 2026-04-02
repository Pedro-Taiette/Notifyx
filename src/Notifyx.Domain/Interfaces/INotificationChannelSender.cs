using Notifyx.Domain.Entities;
using Notifyx.Domain.Enums;

namespace Notifyx.Domain.Interfaces;

public interface INotificationChannelSender
{
    NotificationType Channel { get; }
    Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default);
}
