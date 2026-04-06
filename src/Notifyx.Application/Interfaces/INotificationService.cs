using Notifyx.Application.Contracts;
using Notifyx.Contracts;

namespace Notifyx.Application.Interfaces;

public interface INotificationService
{
    Task<NotificationResponse> SendNotificationAsync(NotificationEvent notificationEvent, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<NotificationResponse>> GetUserNotificationsAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<NotificationResponse>> GetUserUnreadNotificationsAsync(Guid userId, CancellationToken cancellationToken = default);
    Task MarkAsReadAsync(Guid notificationId, CancellationToken cancellationToken = default);
}
