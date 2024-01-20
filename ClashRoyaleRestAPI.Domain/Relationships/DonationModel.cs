using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class DonationModel : IAuditableEntity
{
    private DonationModel() { }
    public PlayerModel? Player { get; private set; }
    public ClanModel? Clan { get; private set; }
    public CardModel? Card { get; private set; }
    public int Amount { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    public static DonationModel Create(PlayerModel player, ClanModel clan, CardModel card, int amount, DateTime date)
    {
        return new DonationModel
        {
            Player = player,
            Clan = clan,
            Card = card,
            Amount = amount,
            Date = date
        };
    }
}
