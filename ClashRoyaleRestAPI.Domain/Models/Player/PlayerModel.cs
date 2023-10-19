using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models.Player
{
    public class PlayerModel : IEntity<int>
    {
        public int Id { get; set; }
        public string? Alias { get; set; }
        public int Elo { get; set; }
        public int Level { get; set; }
        public int Victories { get; set; }
        public int CardAmount { get; set; }
        public int MaxElo { get; set; }
        public CardModel? FavoriteCard { get; set; }
        public List<CollectionModel>? Cards { get; set; }

    }
}
