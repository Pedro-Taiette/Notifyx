namespace Notifyx.Contracts;

public record NotificationEvent(
    Guid UserId,
    string Title,
    string Body,
    NotificationType Type,
    string SourceService,
    string? Metadata = null
);
