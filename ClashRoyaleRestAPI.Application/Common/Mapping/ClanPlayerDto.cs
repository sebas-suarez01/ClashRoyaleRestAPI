using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Application.Common.Mapping
{
    public class ClanPlayerDto
    {
        public PlayerModel? Player { get; set; }
        public RankClan Rank { get; set; }
    }
}
