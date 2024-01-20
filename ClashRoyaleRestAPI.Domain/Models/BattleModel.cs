using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Models;

public class BattleModel : BaseEntity<BattleId>
{
    private BattleModel()
    {
        Id = BattleId.CreateUnique();
    }
    public int AmountTrophies { get; private set; }
    public PlayerModel? Winner { get; private set; }
    public PlayerModel? Loser { get; private set; }
    public int DurationInSeconds { get; private set; }
    public DateTime Date { get; private set; }

    public static BattleModel Create(int amountTrophies,
                                     PlayerModel winner,
                                     PlayerModel loser,
                                     int durationInSeconds,
                                     DateTime date)
    {

        return new BattleModel
        {
            AmountTrophies = amountTrophies,
            Winner = winner,
            Loser = loser,
            DurationInSeconds = durationInSeconds,
            Date = date
        };
    }
}
