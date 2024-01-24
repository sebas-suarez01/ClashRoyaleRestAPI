using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record PlayerNameChangedDomainEvent(Guid Id, Guid PlayerId, string PlayerName) : DomainEvent(Id)
{
}
