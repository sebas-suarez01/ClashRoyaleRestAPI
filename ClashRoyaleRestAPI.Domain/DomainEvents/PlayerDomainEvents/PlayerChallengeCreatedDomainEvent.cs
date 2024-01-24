using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record PlayerChallengeCreatedDomainEvent(Guid Id, Guid PlayerId, Guid ChallengeId) : DomainEvent(Id)
{
}
