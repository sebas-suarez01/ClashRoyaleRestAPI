using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Domain.Relationships
{
    public class DonationModel
    {
        private DonationModel() { }
        public PlayerModel? Player { get; private set; }
        public ClanModel? Clan { get; private set; }
        public CardModel? Card { get; private set; }
        public int Amount { get; private set; }

        public static DonationModel Create(PlayerModel player, ClanModel clan, CardModel card, int amount)
        {
            return new DonationModel
            {
                Player = player,
                Clan = clan,
                Card = card,
                Amount = amount
            };
        }
    }
}
