namespace ClashRoyaleRestAPI.Domain.Models.Card.Implementation
{
    public sealed class StructureModel : CardModel
    {
        public float Radius { get; set; }
        public int HitPoints { get; set; }
        public float HitSpeed { get; set; }
        public int LifeTime { get; set; }
        public float Range { get; set; }

        /*private StructureModel(CardId id,
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

        public static StructureModel Create(
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
                       radius,
                       hitPoints,
                       hitSpeed,
                       lifeTime,
                       range);
        }*/

    }
}
