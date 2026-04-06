using Notifyx.Domain.Entities;
using Notifyx.Contracts;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Infrastructure.Channels;

internal class AllSender(EmailSender emailSender, SmsSender smsSender, InAppSender inAppSender) : INotificationChannelSender
{
    public NotificationType Channel => NotificationType.All;

    public async Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        var results = await Task.WhenAll(
            emailSender.SendAsync(notification, cancellationToken),
            smsSender.SendAsync(notification, cancellationToken),
            inAppSender.SendAsync(notification, cancellationToken));

        return results.All(r => r);
    }
}
