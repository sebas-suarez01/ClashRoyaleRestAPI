using ClashRoyaleRestAPI.Domain.DomainEvents;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Models;

public class BattleModel : Entity<BattleId>
{
    private BattleModel()
    {
        Id = ValueObjectId.CreateUnique<BattleId>();
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
        var battle = new BattleModel
        {
            AmountTrophies = amountTrophies,
            Winner = winner,
            Loser = loser,
            DurationInSeconds = durationInSeconds,
            Date = date
        };

        battle.RaiseDomainEvent(new BattleCreatedDomainEvent(battle.Id, battle.Winner.Id));

        return battle;
    }
}
