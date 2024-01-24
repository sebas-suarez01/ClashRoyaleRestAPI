using ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using System.Text.Json.Serialization;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class CollectionModel : Entity<CollectionId>
{
    private CollectionModel()
    {
        Id = ValueObjectId.CreateUnique<CollectionId>();
    }
    [JsonIgnore]
    public PlayerModel? Player { get; private set; }
    public CardModel? Card { get; private set; }
    public int Level { get; private set; }
    public DateTime Date { get; private set; }

    public static CollectionModel Create(PlayerModel player, CardModel card, int Level, DateTime date)
    {
        var collection = new CollectionModel()
        {
            Player = player,
            Card = card,
            Level = Level,
            Date = date
        };

        collection.RaiseDomainEvent(new CollectionCreatedDomainEvent(Guid.NewGuid(), player.Id.Value, card.Id));

        return collection;
    }
}
