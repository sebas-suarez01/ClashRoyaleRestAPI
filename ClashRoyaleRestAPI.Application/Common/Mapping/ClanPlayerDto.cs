using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Common.Mapping
{
    public class ClanPlayerDto
    {
        public PlayerModel? Player { get; set; }
        public RankClan Rank { get; set; }
    }
}
