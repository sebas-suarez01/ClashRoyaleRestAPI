using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record ChallengeCreatedDomainEvent(Guid Id, Guid ChallengeId) : DomainEvent(Id)
{
}
