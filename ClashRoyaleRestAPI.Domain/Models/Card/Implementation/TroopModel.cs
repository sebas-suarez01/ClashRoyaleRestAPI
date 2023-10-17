using ClashRoyaleRestAPI.Domain.Common.Enum;

namespace ClashRoyaleRestAPI.Domain.Models.Card.Implementation
{
    public sealed class TroopModel : CardModel
    {
        public int HitPoints { get; set; }
        public int Amount { get; set; }
        public float Range { get; set; }
        public SpeedCardEnum Speed { get; set; }
        public float HitSpeed { get; set; }
        public TransportCardEnum Transport { get; set; }

        public TroopModel AddId(int id)
        {
            Id = id;
            return this;
        }
        /*private TroopModel(CardId id,
                      string? name,
                      TypeCardEnum type,
                      string? description,
                      int elixir,
                      QualityCardEnum quality,
                      int damage,
                      bool areaDamage,
                      TargetCardEnum target,
                      int initialLevel,
                      string? imageUrl,
                      int hitPoints,
                      int amount,
                      float range,
                      SpeedCardEnum speed,
                      float hitSpeed,
                      TransportCardEnum transport)
            : base(id,
                   name,
                   type,
                   description,
                   elixir,
                   quality,
                   damage,
                   areaDamage,
                   target,
                   initialLevel,
                   imageUrl)
        {
            HitPoints = hitPoints;
            Amount = amount;
            Range = range;
            Speed = speed;
            HitSpeed = hitSpeed;
            Transport = transport;
        }

        public static TroopModel Create(
                      string? name,
                      TypeCardEnum type,
                      string? description,
                      int elixir,
                      QualityCardEnum quality,
                      int damage,
                      bool areaDamage,
                      TargetCardEnum target,
                      int initialLevel,
                      string? imageUrl,
                      int hitPoints,
                      int amount,
                      float range,
                      SpeedCardEnum speed,
                      float hitSpeed,
                      TransportCardEnum transport)
        {
            return new(CardId.CreateUnique(),
                       name,
                       type,
                       description,
                       elixir,
                       quality,
                       damage,
                       areaDamage,
                       target,
                       initialLevel,
                       imageUrl,
                       hitPoints,
                       amount,
                       range,
                       speed,
                       hitSpeed,
                       transport);
        }*/
    }
}
