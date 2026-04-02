using Notifyx.Domain.Enums;

namespace Notifyx.Application.Contracts;

public record NotificationResponse(
    Guid Id, 
    string Title,
    string Body,
    NotificationType Type,
    NotificationStatus Status,
    DateTime CreatedAt,
    DateTime? ReadAt
);
