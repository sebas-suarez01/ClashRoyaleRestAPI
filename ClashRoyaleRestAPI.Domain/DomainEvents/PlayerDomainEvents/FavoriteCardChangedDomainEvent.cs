using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;

public record FavoriteCardChangedDomainEvent(Guid Id, Guid PlayerId, int CardId) : DomainEvent(Id)
{
}
