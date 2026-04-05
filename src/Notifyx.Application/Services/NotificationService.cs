using Notifyx.Application.Contracts;
using Notifyx.Application.Interfaces;

namespace Notifyx.Application.Services;

internal class NotificationService : INotificationService
{
    public Task<IReadOnlyList<NotificationResponse>> GetUserNotificationsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<NotificationResponse>> GetUserUnreadNotificationsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task MarkAsReadAsync(Guid notificationId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<NotificationResponse> SendNotificationAsync(NotificationEvent notificationEvent, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
