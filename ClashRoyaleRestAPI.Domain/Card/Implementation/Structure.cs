using ClashRoyaleRestAPI.Domain.Card.Enum;
using ClashRoyaleRestAPI.Domain.Card.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card.Implementation
{
    public sealed class Structure : Card
    {
        public float Radius { get; set; }
        public int HitPoints { get; set; }
        public float HitSpeed { get; set; }
        public int LifeTime { get; set; }
        public float Range { get; set; }

        private Structure(CardId id,
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
                      float radius,
                      int hitPoints,
                      float hitSpeed,
                      int lifeTime,
                      float range)
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
            Radius = radius;
            HitPoints = hitPoints;
            HitSpeed = hitSpeed;
            LifeTime = lifeTime;
            Range = range;
        }

        public static Structure Create(
            CardId id,
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
            float radius,
            int hitPoints,
            float hitSpeed,
            int lifeTime,
            float range)
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
                       radius,
                       hitPoints,
                       hitSpeed,
                       lifeTime,
                       range);
        }


    }
}
