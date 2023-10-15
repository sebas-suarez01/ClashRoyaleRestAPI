namespace ClashRoyaleRestAPI.Domain.Models.Card.Implementation
{
    public sealed class SpellModel : CardModel
    {
        public float Radius { get; set; }
        public int TowerDamage { get; set; }
        public int LifeTime { get; set; }

        /*private SpellModel(CardId id,
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

        public static SpellModel Create(
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
                CardId.CreateUnique(),
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
        }*/
    }
}
