using ClashRoyaleRestAPI.Domain.Common.Enum;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Models.Card.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Models.Card
{
    public abstract class CardModel : IEntity<int>
    {
        /*protected CardModel(CardId id, string? name, TypeCardEnum type, string? description, int elixir,
                       QualityCardEnum quality, int damage, bool areaDamage, TargetCardEnum target, int initialLevel,
                       string? imageUrl) : base(id)
        {
            Name = name;
            Type = type;
            Description = description;
            Elixir = elixir;
            Quality = quality;
            Damage = damage;
            AreaDamage = areaDamage;
            Target = target;
            InitialLevel = initialLevel;
            ImageUrl = imageUrl;
        }*/

        public int Id { get; set; }
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
}
