using ClashRoyaleRestAPI.Domain.Common.Enum;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Common.Relationships
{
    public class ClanPlayersModel
    {
        public ClanModel? Clan { get; set; }
        public PlayerModel? Player { get; set; }
        public RankClan Rank { get; set; }
    }
}
