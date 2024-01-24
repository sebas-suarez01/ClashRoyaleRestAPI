using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record DonationCreatedDomainEvent(Guid Id, Guid ClanId, Guid PlayerId, int CardId) : DomainEvent(Id)
{
}
