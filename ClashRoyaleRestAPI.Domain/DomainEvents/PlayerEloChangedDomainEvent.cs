using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record PlayerEloChangedDomainEvent(PlayerId PlayerId, int PlayerElo) : DomainEvent
{
}
