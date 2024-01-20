using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record ChallengeCreatedDomainEvent(int Id) : IDomainEvent
{
}
