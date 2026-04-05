using Notifyx.Application.Contracts;
using Notifyx.Application.Interfaces;
using Notifyx.Domain.Entities;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Application.Services;

internal class NotificationService(
    INotificationRepository repository,
    IEnumerable<INotificationChannelSender> senders) : INotificationService
{
    public async Task<NotificationResponse> SendNotificationAsync(NotificationEvent notificationEvent, CancellationToken cancellationToken = default)
    {
        var notification = Notification.Create(
            notificationEvent.UserId,
            notificationEvent.Title,
            notificationEvent.Body,
            notificationEvent.Type,
            notificationEvent.Metadata,
            notificationEvent.SourceService);

        await repository.AddAsync(notification, cancellationToken);

        var sender = senders.FirstOrDefault(s => s.Channel == notification.Type);

        if (sender is not null)
        {
            var success = await sender.SendAsync(notification, cancellationToken);

            if (!success)
                notification.MarkAsFailed();
        }
        else
        {
            notification.MarkAsFailed();
        }

        await repository.UpdateAsync(notification, cancellationToken);

        return ToResponse(notification);
    }

    public async Task<IReadOnlyList<NotificationResponse>> GetUserNotificationsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var notifications = await repository.GetByUserIdAsync(userId, cancellationToken);
        return notifications.Select(ToResponse).ToList();
    }

    public async Task<IReadOnlyList<NotificationResponse>> GetUserUnreadNotificationsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var notifications = await repository.GetByUserIdAsync(userId, cancellationToken);
        return notifications
            .Where(n => n.Status != Domain.Enums.NotificationStatus.Read)
            .Select(ToResponse)
            .ToList();
    }

    public async Task MarkAsReadAsync(Guid notificationId, CancellationToken cancellationToken = default)
    {
        var notification = await repository.GetByIdAsync(notificationId, cancellationToken);

        if (notification is null)
            return;

        notification.MarkAsRead();
        await repository.UpdateAsync(notification, cancellationToken);
    }

    private static NotificationResponse ToResponse(Notification n) =>
        new(n.Id, n.Title, n.Body, n.Type, n.Status, n.CreatedAt, n.ReadAt);
}
