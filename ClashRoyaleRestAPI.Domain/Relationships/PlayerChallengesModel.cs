using ClashRoyaleRestAPI.Domain.Models.Challenge;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Relationships
{
    public class PlayerChallengesModel
    {
        private PlayerChallengesModel() { }
        public PlayerModel? Player { get; private set; }
        public ChallengeModel? Challenge { get; private set; }
        public int PrizeAmount { get; private set; }

        public static PlayerChallengesModel Create(PlayerModel player, ChallengeModel challenge, int prizeAmount)
        {
            return new PlayerChallengesModel
            {
                Player = player,
                Challenge = challenge,
                PrizeAmount = prizeAmount
            };
        }
    }
}
