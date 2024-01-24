using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record PlayerEloChangedDomainEvent(Guid Id, Guid PlayerId, int PlayerElo) : DomainEvent(Id)
{
}
