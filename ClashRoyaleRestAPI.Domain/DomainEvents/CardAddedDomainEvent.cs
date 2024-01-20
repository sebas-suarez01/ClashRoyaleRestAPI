using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record CardAddedDomainEvent(PlayerId PlayerId, int CardId) : DomainEvent
{
}
