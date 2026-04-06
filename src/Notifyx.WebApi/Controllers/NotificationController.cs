using Microsoft.AspNetCore.Mvc;
using Notifyx.Contracts;
using Notifyx.Application.Interfaces;

namespace Notifyx.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(INotificationService notificationService) : ControllerBase
{
    [HttpGet("[action]/{userId:Guid}")]
    public async Task<IActionResult> GetUserNotifications(Guid userId, CancellationToken cancellationToken)
    {
        var notifications = await notificationService.GetUserNotificationsAsync(userId, cancellationToken);
        return Ok(notifications);
    }

    [HttpGet("[action]/{userId:Guid}")]
    public async Task<IActionResult> GetUserUnreadNotifications(Guid userId, CancellationToken cancellationToken)
    {
        var notifications = await notificationService.GetUserUnreadNotificationsAsync(userId, cancellationToken);
        return Ok(notifications);
    }

    [HttpPatch("[action]/{notificationId:Guid}")]
    public async Task<IActionResult> MarkAsRead(Guid notificationId, CancellationToken cancellationToken)
    {
        await notificationService.MarkAsReadAsync(notificationId, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] NotificationEvent notificationEvent, CancellationToken cancellationToken)
    {
        var result = await notificationService.SendNotificationAsync(notificationEvent, cancellationToken);
        return CreatedAtAction(nameof(GetUserNotifications), new { userId = result.Id }, result);
    }
}
