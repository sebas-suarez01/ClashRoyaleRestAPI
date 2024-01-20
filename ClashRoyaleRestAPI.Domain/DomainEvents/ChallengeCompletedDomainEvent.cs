using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record ChallengeCompletedDomainEvent(PlayerId PlayerId, ChallengeId ChallengeId) : DomainEvent
{
}
