using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Outbox;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;

namespace ClashRoyaleRestAPI.Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public class ProcessOutboxMessagesJob : IJob
{
    private readonly ClashRoyaleDbContext _dbContext;
    private readonly IPublisher _publisher;
    public ProcessOutboxMessagesJob(ClashRoyaleDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var outboxMessages = await _dbContext
            .Set<OutboxMessage>()
            .Where(om=> om.ProcessedOnUtc == null)
            .Take(20)
            .ToListAsync(context.CancellationToken);

        foreach (var message in outboxMessages)
        {
            var domainEvent = JsonConvert
                .DeserializeObject<DomainEvent>(
                    message.Content,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                    });

            if (domainEvent is null)
                continue;

            await _publisher.Publish(domainEvent, context.CancellationToken);

            message.ProcessedOnUtc = DateTime.UtcNow;
        }

        await _dbContext.SaveChangesAsync();
    }
}
