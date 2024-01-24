using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;

public record PlayerRankUpdatedDomainEvent(Guid Id, Guid ClanId, Guid PlayerId, RankClan Rank) : DomainEvent(Id)
{
}
