using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record PlayerAddedDomainEvent(ClanId ClanId, PlayerId PlayerId) : DomainEvent
{
}
