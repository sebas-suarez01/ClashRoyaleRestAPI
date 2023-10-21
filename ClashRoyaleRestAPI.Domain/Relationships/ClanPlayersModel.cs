using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Relationships
{
    public class ClanPlayersModel
    {
        private ClanPlayersModel() { }
        public ClanModel? Clan { get; set; }
        public PlayerModel? Player { get; set; }
        public RankClan Rank { get; set; }
        public static ClanPlayersModel Create(PlayerModel player, ClanModel clan, RankClan rank)
        {
            var playerClan = new ClanPlayersModel()
            {
                Player = player,
                Clan = clan,
                Rank = rank
            };

            return playerClan;
        }
    }
}
