using ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using System.Text.Json.Serialization;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class ClanPlayersModel : Entity<ClanPlayersId>
{
    private ClanPlayersModel()
    {
        Id = ClanPlayersId.CreateUnique();
    }

    [JsonIgnore]
    public ClanModel? Clan { get; private set; }
    public PlayerModel? Player { get; private set; }
    public RankClan Rank { get; private set; }

    public static ClanPlayersModel Create(PlayerModel player, ClanModel clan, RankClan rank)
    {
        var playerClan = new ClanPlayersModel()
        {
            Player = player,
            Clan = clan,
            Rank = rank
        };

        playerClan.RaiseDomainEvent(new ClanPlayerCreatedDomainEvent(clan.Id, player.Id));

        return playerClan;
    }

    public void UpdateRank(RankClan rank)
    {
        Rank = rank;

        RaiseDomainEvent(new PlayerRankUpdatedDomainEvent(Clan!.Id, Player!.Id, rank));
    }
}
