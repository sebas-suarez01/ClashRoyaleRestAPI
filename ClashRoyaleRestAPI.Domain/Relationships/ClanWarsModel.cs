using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class ClanWarsModel : IAuditableEntity
{
    private ClanWarsModel() { }
    public ClanModel? Clan { get; private set; }
    public WarModel? War { get; private set; }
    public int Prize { get; private set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public static ClanWarsModel Create(ClanModel clan, WarModel war, int prize)
    {
        return new ClanWarsModel()
        {
            Clan = clan,
            War = war,
            Prize = prize
        };
    }
}
