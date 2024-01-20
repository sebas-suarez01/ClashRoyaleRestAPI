using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record PlayerRemovedDomainEvent(ClanId ClanId, PlayerId PlayerId) : DomainEvent
{
}
