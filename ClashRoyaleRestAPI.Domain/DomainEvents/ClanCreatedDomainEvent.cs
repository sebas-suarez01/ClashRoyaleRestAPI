using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record ClanCreatedDomainEvent(ClanId ClanId) : DomainEvent
{
}
