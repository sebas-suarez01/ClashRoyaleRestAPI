using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Models;

public class WarModel : BaseEntity<WarId>
{
    private WarModel() 
    {
        Id = WarId.CreateUnique();
    }
    public DateTime StartDate { get; private set; }

    public static WarModel Create(DateTime start)
    {
        return new WarModel()
        {
            StartDate = start,
        };
    }
}
