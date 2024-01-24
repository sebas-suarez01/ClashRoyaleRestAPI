using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record PlayerCreatedDomainEvent(Guid Id,Guid PlayerId) : DomainEvent(Id)
{
}
