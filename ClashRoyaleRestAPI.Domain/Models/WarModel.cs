using ClashRoyaleRestAPI.Domain.DomainEvents;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Models;

public class WarModel : Entity<WarId>
{
    private WarModel(Guid id)
    {
        Id = ValueObjectId.Create<WarId>(id);
    }
    private WarModel() 
    {
    }
    public DateTime StartDate { get; private set; }

    public static WarModel Create(DateTime start)
    {
        var war = new WarModel(Guid.NewGuid())
        {
            StartDate = start,
        };

        war.RaiseDomainEvent(new WarCreatedDomainEvent(Guid.NewGuid(), war.Id.Value));

        return war;
    }
}
