using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record ClanMinTrophiesChangedDomainEvent(Guid Id, Guid ClanId, int MinTrophies) : DomainEvent(Id)
{
}
