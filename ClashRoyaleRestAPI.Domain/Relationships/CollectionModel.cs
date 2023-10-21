using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Relationships
{
    public class CollectionModel
    {
        private CollectionModel() { }
        public PlayerModel? Player { get; set; }
        public CardModel? Card { get; set; }
        public int Level { get; set; }
        public DateTime Date { get; set; }

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
}
