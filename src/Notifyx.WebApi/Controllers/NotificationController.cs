using Microsoft.AspNetCore.Mvc;
using Notifyx.Application.Contracts;
using Notifyx.Application.Interfaces;

namespace Notifyx.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(INotificationService notificationService): ControllerBase
{
    // GET User Notifications
    // Patch Mark Notification as Read
    // Post Manual Endpoint to trigger notification for testing
}
