using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.Models.Card;

public abstract class CardModel : Entity<int>
{
    public string? Name { get; set; }
    public TypeCardEnum Type { get; set; }
    public string? Description { get; set; }
    public int Elixir { get; set; }
    public QualityCardEnum Quality { get; set; }
    public int Damage { get; set; }
    public bool AreaDamage { get; set; }
    public TargetCardEnum Target { get; set; }
    public int InitialLevel { get; set; }
    public string? ImageUrl { get; set; }

}
