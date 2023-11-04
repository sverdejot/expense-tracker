using Domain.Shared.Base;
using Newtonsoft.Json;
using Persistance.Outbox;

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
        // Save changes timestamps and other audit information
    }
}
