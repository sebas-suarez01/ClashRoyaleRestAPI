using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record ClanPlayerCreatedDomainEvent(Guid Id, Guid ClanId, Guid PlayerId) : DomainEvent(Id)
{
}
