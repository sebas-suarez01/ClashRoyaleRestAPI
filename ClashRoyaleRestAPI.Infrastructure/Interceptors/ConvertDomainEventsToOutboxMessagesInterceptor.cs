using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace ClashRoyaleRestAPI.Infrastructure.Interceptors;

internal class ConvertDomainEventsToOutboxMessagesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {

        DbContext? context = eventData.Context;

        if (context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var outboxMessages = context.ChangeTracker
                .Entries<IDomainEventContainer>()
                .Select(x => x.Entity)
                .SelectMany(x =>
                {
                    var domainEvents = x.GetDomainEvents();

                    x.ClearDomainEvents();

                    return domainEvents;
                })
                .Select(domainEvent => new OutboxMessage()
                {
                    Id = Guid.NewGuid(),
                    Type = domainEvent.GetType().Name,
                    OccurredOnUtc = DateTime.UtcNow,
                    Content = JsonConvert.SerializeObject(
                        domainEvent,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All,
                        })
                })
                .ToList();

        context.Set<OutboxMessage>().AddRange(outboxMessages);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
