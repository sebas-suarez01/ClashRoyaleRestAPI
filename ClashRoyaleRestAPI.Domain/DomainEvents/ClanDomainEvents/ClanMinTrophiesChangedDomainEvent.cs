using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record ClanMinTrophiesChangedDomainEvent(ClanId ClanId, int MinTrophies) : DomainEvent
{
}
