using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record PlayerRankUpdatedDomainEvent(ClanId ClanId, PlayerId PlayerId, RankClan Rank) : DomainEvent
{
}
