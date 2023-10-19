using ClashRoyaleRestAPI.Domain.Models.Challenge;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Relationships
{
    public class PlayerChallengesModel
    {
        public PlayerModel? Player { get; set; }
        public ChallengeModel? Challenge { get; set; }
        public int PrizeAmount { get; set; }
    }
}
