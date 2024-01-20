using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models;

public class ClanModel : BaseEntity<ClanId>
{
    private ClanModel() 
    {
        Id = ClanId.CreateUnique();
    }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public string? Region { get; private set; }
    public bool TypeOpen { get; private set; }
    public int AmountMembers { get; private set; }
    public int TrophiesInWar { get; private set; }
    public int MinTrophies { get; private set; }

    private readonly List<ClanPlayersModel> _players = new();
    public IReadOnlyCollection<ClanPlayersModel> Players => _players;

    public static ClanModel Create(string name, string description, string region, bool isOpen,
         int trophiesInWar, int minTrophies)
    {
        return new ClanModel
        {
            Name = name,
            Description = description,
            Region = region,
            TypeOpen = isOpen,
            TrophiesInWar = trophiesInWar,
            MinTrophies = minTrophies
        };
    }
    public static ClanModel Create(Guid id, string name, string description, string region, bool isOpen,
         int trophiesInWar, int minTrophies)
    {
        return new ClanModel
        {
            Id = ClanId.Create(id),
            Name = name,
            Description = description,
            Region = region,
            TypeOpen = isOpen,
            TrophiesInWar = trophiesInWar,
            MinTrophies = minTrophies
        };
    }

    public void AddPlayer(PlayerModel player, RankClan rank = RankClan.Member)
    {
        var playerClan = ClanPlayersModel.Create(player, this, rank);

        _players.Add(playerClan);
    }

    public void AddAmountMember()
    {
        AmountMembers += 1;
    }
    public void RemoveAmountMember()
    {
        AmountMembers -= 1;
    }
    public void ChangeTypeOpen()
    {
        TypeOpen = !TypeOpen;
    }
    public void AddMinTrophies(int minTrophies)
    {
        MinTrophies = minTrophies;
    }


}
