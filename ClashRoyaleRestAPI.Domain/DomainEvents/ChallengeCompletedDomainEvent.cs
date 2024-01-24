using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record ChallengeCompletedDomainEvent(Guid Id, Guid PlayerId, Guid ChallengeId) : DomainEvent(Id)
{
}
