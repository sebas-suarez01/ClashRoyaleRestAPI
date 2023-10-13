using ClashRoyaleRestAPI.Domain.Card.Enum;
using ClashRoyaleRestAPI.Domain.Card.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card.Implementation
{
    public sealed class Troop : Card
    {
        public int HitPoints { get; set; }
        public int Amount { get; set; }
        public float Range { get; set; }
        public SpeedCardEnum Speed { get; set; }
        public float HitSpeed { get; set; }
        public TransportCardEnum Transport { get; set; }

        private Troop(CardId id,
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

        public static Troop Create(CardId id,
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
            return new(id,
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
        }
    }
}
