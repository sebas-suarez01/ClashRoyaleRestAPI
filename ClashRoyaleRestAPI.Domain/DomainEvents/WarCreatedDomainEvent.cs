using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record WarCreatedDomainEvent(Guid Id, Guid WarId) : DomainEvent(Id)
{
}
