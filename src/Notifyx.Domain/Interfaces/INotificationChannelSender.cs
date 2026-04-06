using Notifyx.Contracts;
using Notifyx.Domain.Entities;

namespace Notifyx.Domain.Interfaces;

public interface INotificationChannelSender
{
    NotificationType Channel { get; }
    Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default);
}
