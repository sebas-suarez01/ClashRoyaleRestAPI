using ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class ClanWarsModel : Entity<ClanWarsId>
{
    private ClanWarsModel()
    {
        Id = ValueObjectId.CreateUnique<ClanWarsId>();
    }
    public ClanModel? Clan { get; private set; }
    public WarModel? War { get; private set; }
    public int Prize { get; private set; }
    public static ClanWarsModel Create(ClanModel clan, WarModel war, int prize)
    {
        var clanWar = new ClanWarsModel()
        {
            Clan = clan,
            War = war,
            Prize = prize
        };

        clanWar.RaiseDomainEvent(new ClanWarCreatedDomainEvent(war.Id, clan.Id));

        return clanWar;
    }
}
