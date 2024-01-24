using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record BattleCreatedDomainEvent(Guid Id, Guid BattleId, Guid WinnerId) : DomainEvent(Id)
{
}
