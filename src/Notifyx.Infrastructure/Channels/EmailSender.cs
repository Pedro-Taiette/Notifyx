using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Notifyx.Domain.Entities;
using Notifyx.Contracts;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Infrastructure.Channels;

internal class EmailSender(IConfiguration configuration) : INotificationChannelSender
{
    public NotificationType Channel => NotificationType.Email;

    public async Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        var smtp = configuration.GetSection("Smtp");

        using var client = new SmtpClient(smtp["Host"], int.Parse(smtp["Port"]!))
        {
            Credentials = new NetworkCredential(smtp["Username"], smtp["Password"]),
            EnableSsl = true
        };

        using var message = new MailMessage(
            from: smtp["From"]!,
            to: smtp["To"]!,
            subject: notification.Title,
            body: notification.Body);

        await client.SendMailAsync(message, cancellationToken);

        notification.MarkAsSent();
        return true;
    }
}
