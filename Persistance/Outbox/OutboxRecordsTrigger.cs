using Domain.Shared.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistance.Outbox;
using Quartz;

namespace Persistance.Jobs;

[DisallowConcurrentExecution]
public class OutboxRecordsTrigger : IJob
{
    private readonly ApplicationDbContext _context;

    private readonly IPublisher _publisher;
    public OutboxRecordsTrigger(ApplicationDbContext context, IPublisher publisher)
    {
        this._context = context;
        this._publisher = publisher;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            // Do not hardcode this, read from configuration
            List<OutboxRecord> records = await this._context
                .Set<OutboxRecord>()
                .Where(record => record.ProcessedAt == null)
                .Take(20)
                .ToListAsync(context.CancellationToken);

           foreach (var record in records)
            {
                var Event = JsonConvert
                    .DeserializeObject<IDomainEvent>(
                        record.Content,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All,
                        });

                if (Event is null)
                {
                    continue;
                    // Add proper logging or Exception Throwing
                }

                await _publisher.Publish(Event, context.CancellationToken);

                record.ProcessedAt = DateTime.UtcNow;
            }

            await this._context.SaveChangesAsync();
        } catch (Exception ex)
        {
            // Proper logging and error recovery, TBC
        }
        
    }
}
