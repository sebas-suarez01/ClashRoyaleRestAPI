using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives;
using System.Text.Json.Serialization;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class ClanPlayersModel : IAuditableEntity
{
    private ClanPlayersModel() { }

    [JsonIgnore]
    public ClanModel? Clan { get; private set; }
    public PlayerModel? Player { get; private set; }
    public RankClan Rank { get; private set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

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

    public void UpdateRank(RankClan rank)
    {
        Rank = rank;
    }
}
