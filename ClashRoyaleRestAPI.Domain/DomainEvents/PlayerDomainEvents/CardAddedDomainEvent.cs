using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record CardAddedDomainEvent(Guid Id, Guid PlayerId, int CardId) : DomainEvent(Id)
{
}
