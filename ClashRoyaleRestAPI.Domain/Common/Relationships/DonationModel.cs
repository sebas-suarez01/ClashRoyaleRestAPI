using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Common.Relationships
{
    public class DonationModel
    {
        public PlayerModel? Player { get; set; }
        public ClanModel? Clan { get; set; }
        public CardModel? Card { get; set; }
        public int Amount { get; set; }
    }
}
