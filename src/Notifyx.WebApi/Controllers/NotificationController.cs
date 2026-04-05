using Microsoft.AspNetCore.Mvc;
using Notifyx.Application.Contracts;
using Notifyx.Application.Interfaces;

namespace Notifyx.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(INotificationService notificationService): ControllerBase
{
    [HttpGet("[action]/{userId : Guid}")]
    public IActionResult GetUserNotifications(Guid userId)
    {
        var notifications = notificationService.GetUserNotificationsAsync(userId);
        return Ok(notifications);
    }
    [HttpGet("[action]/{userId : Guid}")]
    public IActionResult GetUserUnreadNotifications(Guid userId)
    {
        var notifications = notificationService.GetUserUnreadNotificationsAsync(userId);
        return Ok(notifications);
    }
    [HttpGet("[action]/{notificationId : Guid}")]
    public IActionResult MarkAsRead(Guid notificationId)
    {
        notificationService.MarkAsReadAsync(notificationId);
        return NoContent();
    }
    [HttpPost]
    public IActionResult SendNotification([FromBody]NotificationEvent notificationEvent)
    {
        notificationService.SendNotificationAsync(notificationEvent);
        return NoContent();
    }
    // Post Manual Endpoint to trigger notification for testing
}
