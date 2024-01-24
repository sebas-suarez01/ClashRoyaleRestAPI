using ClashRoyaleRestAPI.Domain.DomainEvents;
using ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class PlayerChallengesModel : Entity<PlayerChallengesId>
{
    private PlayerChallengesModel()
    {
        Id = ValueObjectId.CreateUnique<PlayerChallengesId>();
    }
    public PlayerModel? Player { get; private set; }
    public ChallengeModel? Challenge { get; private set; }
    public int PrizeAmount { get; private set; }
    public bool IsCompleted { get; private set; }

    public static PlayerChallengesModel Create(PlayerModel player, ChallengeModel challenge, int prizeAmount)
    {
        var playerChallenge = new PlayerChallengesModel
        {
            Player = player,
            Challenge = challenge,
            PrizeAmount = prizeAmount
        };

        playerChallenge.RaiseDomainEvent(new PlayerChallengeCreatedDomainEvent(Guid.NewGuid(),
                                                                               player.Id.Value,
                                                                               challenge.Id.Value));

        return playerChallenge;
    }

    public void Completed()
    {
        if (!IsCompleted)
            IsCompleted = true;

        RaiseDomainEvent(new ChallengeCompletedDomainEvent(Guid.NewGuid(), Player!.Id.Value, Challenge!.Id.Value));
    }

    public void AddReward(int amount)
    {
        PrizeAmount += amount;
    }
}
