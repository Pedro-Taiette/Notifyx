using Notifyx.Domain.Entities;
using Notifyx.Domain.Interfaces;

namespace Notifyx.Infrastructure.Persistence.Repository;

internal class NotificationRepository : INotificationRepository
{
    public Task AddAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Notification?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Notification>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
