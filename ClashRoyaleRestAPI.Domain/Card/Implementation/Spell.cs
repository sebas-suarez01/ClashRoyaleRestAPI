using ClashRoyaleRestAPI.Domain.Card.Enum;
using ClashRoyaleRestAPI.Domain.Card.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card.Implementation
{
    public sealed class Spell : Card
    {
        public float Radius { get; set; }
        public int TowerDamage { get; set; }
        public int LifeTime { get; set; }

        private Spell(CardId id,
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
                      int towerDamage,
                      int lifeTime)
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
            TowerDamage = towerDamage;
            LifeTime = lifeTime;
        }

        public static Spell Create(
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
            int towerDamage,
            int lifeTime)
        {
            return new(
                id,
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
                towerDamage,
                lifeTime);
        }
    }
}
