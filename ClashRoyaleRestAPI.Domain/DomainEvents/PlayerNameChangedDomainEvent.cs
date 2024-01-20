using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record PlayerNameChangedDomainEvent(PlayerId PlayerId, string PlayerName) : DomainEvent
{
}
