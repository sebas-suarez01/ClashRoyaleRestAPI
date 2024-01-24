using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record ClanWarCreatedDomainEvent(Guid Id, Guid WarId, Guid ClanId) : DomainEvent(Id)
{
}
