using Microsoft.EntityFrameworkCore;
using Notifyx.Domain.Entities;

namespace Notifyx.Infrastructure.Persistence;

public class NotificationDBContext(DbContextOptions<NotificationDBContext> options) : DbContext(options)
{
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(256);
            entity.Property(e => e.Body).HasMaxLength(4000);
            entity.Property(e => e.SourceService).HasMaxLength(128);
            entity.Property(e => e.Type).HasConversion<string>();
            entity.Property(e => e.Status).HasConversion<string>();
            entity.HasIndex(e => e.UserId);
        });
    }
}
