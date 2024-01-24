using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record ClanCreatedDomainEvent(Guid Id, Guid ClanId) : DomainEvent(Id)
{
}
