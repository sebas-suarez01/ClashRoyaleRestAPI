using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record DonationCreatedDomainEvent(ClanId ClanId, PlayerId PlayerId, int CardId) : DomainEvent
{
}
