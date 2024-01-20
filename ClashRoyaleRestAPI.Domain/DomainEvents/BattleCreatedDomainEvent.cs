using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record BattleCreatedDomainEvent(Guid id) : IDomainEvent
{
}
