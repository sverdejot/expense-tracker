using System.Dynamic;
using System.Security.Cryptography;
using Domain;
using Domain.Shared.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Persistance.Outbox;
using Quartz.Xml.JobSchedulingData20;

namespace Persistance;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        CastEventsToOutboxRecords();
        AuditChanges();
        return _context.SaveChangesAsync(cancellationToken);
    }

    private void CastEventsToOutboxRecords()
    {
        // Cast domain events to outbox-like messages to be persisted on the database
        var messages = this._context.ChangeTracker
            .Entries<IDomainEventRecorder>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot =>
            {
                var events = aggregateRoot.GetEvents();

                aggregateRoot.ClearEvents();

                return events;
            })
            .Select(domainEvent => new OutboxRecord
            {
                Id = Guid.NewGuid(),
                Type = domainEvent.GetType().Name,
                Content = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                }),
                CreatedAt = DateTime.UtcNow

            })
            .ToList();

        _context.OutboxRecords.AddRange(messages);
    }

    private void AuditChanges()
    {
        DateTime utcNow = DateTime.UtcNow;

        _context.ChangeTracker.Entries<IAuditable>()
            .Where(entity => entity.State is EntityState.Modified || entity.State is EntityState.Added)
            .ToList()
            .ForEach(entity => GetAuditProperty(entity).CurrentValue = utcNow);
    }

    private static PropertyEntry GetAuditProperty(EntityEntry<IAuditable> entity) =>
        entity.State switch
        {
            EntityState.Added => entity.Property(nameof(IAuditable.CreatedOnUtc)),
            EntityState.Modified => entity.Property(nameof(IAuditable.ModifiedOnUtc)),
            _ => throw new ArgumentOutOfRangeException(entity.State.ToString())
        };
}
