using ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models;

public class ClanModel : Entity<ClanId>
{
    private ClanModel(Guid id)
    {
        Id = ValueObjectId.Create<ClanId>(id);
    }
    private ClanModel()
    {
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
        var clan = new ClanModel(Guid.NewGuid())
        {
            Name = name,
            Description = description,
            Region = region,
            TypeOpen = isOpen,
            TrophiesInWar = trophiesInWar,
            MinTrophies = minTrophies
        };

        clan.RaiseDomainEvent(new ClanCreatedDomainEvent(Guid.NewGuid(), clan.Id.Value));

        return clan;
    }
    public static ClanModel Create(Guid id, string name, string description, string region, bool isOpen,
         int trophiesInWar, int minTrophies)
    {
        return new ClanModel
        {
            Id = ValueObjectId.Create<ClanId>(id),
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

        RaiseDomainEvent(new PlayerAddedDomainEvent(Guid.NewGuid(), Id.Value, player.Id.Value));
    }
    public void RemovePlayer(PlayerModel player, RankClan rank = RankClan.Member)
    {
        var playerClan = ClanPlayersModel.Create(player, this, rank);

        _players.Remove(playerClan);

        RaiseDomainEvent(new PlayerRemovedDomainEvent(Guid.NewGuid(), Id.Value, player.Id.Value));
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

        RaiseDomainEvent(new ClanTypeChangedDomainEvent(Guid.NewGuid(), Id.Value));
    }
    public void AddMinTrophies(int minTrophies)
    {
        MinTrophies = minTrophies;

        RaiseDomainEvent(new ClanMinTrophiesChangedDomainEvent(Guid.NewGuid(), Id.Value, minTrophies));
    }


}
