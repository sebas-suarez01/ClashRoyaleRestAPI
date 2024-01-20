using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record BattleCreatedDomainEvent(BattleId BattleId, PlayerId WinnerId) : DomainEvent
{
}
