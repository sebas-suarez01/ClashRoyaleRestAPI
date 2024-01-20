using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives;
using System.Text.Json.Serialization;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class CollectionModel : IAuditableEntity
{
    private CollectionModel() { }

    [JsonIgnore]
    public PlayerModel? Player { get; private set; }
    public CardModel? Card { get; private set; }
    public int Level { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    public static CollectionModel Create(PlayerModel player, CardModel card, int Level, DateTime date)
    {
        var collection = new CollectionModel()
        {
            Player = player,
            Card = card,
            Level = Level,
            Date = date
        };

        return collection;
    }
}
