using ClashRoyaleRestAPI.Domain.DomainEvents;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Models;

public class WarModel : Entity<WarId>
{
    private WarModel() 
    {
        Id = WarId.CreateUnique();
    }
    public DateTime StartDate { get; private set; }

    public static WarModel Create(DateTime start)
    {
        var war = new WarModel()
        {
            StartDate = start,
        };

        war.RaiseDomainEvent(new WarCreatedDomainEvent(war.Id));

        return war;
    }
}
