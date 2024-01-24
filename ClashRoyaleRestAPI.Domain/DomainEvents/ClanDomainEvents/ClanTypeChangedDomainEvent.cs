using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record ClanTypeChangedDomainEvent(Guid Id, Guid ClanId) : DomainEvent(Id)
{
}
