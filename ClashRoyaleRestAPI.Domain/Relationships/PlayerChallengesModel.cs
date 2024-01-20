using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class PlayerChallengesModel : IAuditableEntity
{
    private PlayerChallengesModel() { }
    public PlayerModel? Player { get; private set; }
    public ChallengeModel? Challenge { get; private set; }
    public int PrizeAmount { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    public static PlayerChallengesModel Create(PlayerModel player, ChallengeModel challenge, int prizeAmount)
    {
        return new PlayerChallengesModel
        {
            Player = player,
            Challenge = challenge,
            PrizeAmount = prizeAmount
        };
    }

    public void Completed()
    {
        if (!IsCompleted)
            IsCompleted = true;
    }

    public void AddReward(int amount)
    {
        PrizeAmount += amount;
    }
}
