using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Relationships
{
    public class ClanPlayersModel
    {
        public ClanModel? Clan { get; set; }
        public PlayerModel? Player { get; set; }
        public RankClan Rank { get; set; }
    }
}
