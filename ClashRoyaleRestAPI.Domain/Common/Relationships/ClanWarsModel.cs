using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.War;

namespace ClashRoyaleRestAPI.Domain.Common.Relationships
{
    public class ClanWarsModel
    {
        public ClanModel? Clan { get; set; }
        public WarModel? War { get; set; }
        public int Prize { get; set; }
    }
}
