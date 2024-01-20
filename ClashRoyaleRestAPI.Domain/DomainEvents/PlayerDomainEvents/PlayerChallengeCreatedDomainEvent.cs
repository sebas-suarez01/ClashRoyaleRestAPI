using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record PlayerChallengeCreatedDomainEvent(PlayerId PlayerId, ChallengeId ChallengeId) : DomainEvent
{
}
