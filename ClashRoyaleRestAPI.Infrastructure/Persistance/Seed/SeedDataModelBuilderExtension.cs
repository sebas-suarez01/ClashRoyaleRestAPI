using ClashRoyaleRestAPI.Domain.Models.Card.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Seed
{
    public static class SeedDataModelBuilderExtension
    {
        public static void SeedCards(this ModelBuilder modelBuilder)
        {
            int countId = 1;
            var troops = CardsSeed.TroopsCards.Select(x => x.AddId(countId++));
            var spells = CardsSeed.SpellCards.Select(x => x.AddId(countId++));
            var structures = CardsSeed.StructureCards.Select(x => x.AddId(countId++));

            modelBuilder.Entity<TroopModel>().HasData(troops);
            modelBuilder.Entity<SpellModel>().HasData(spells);
            modelBuilder.Entity<StructureModel>().HasData(structures);
        }
    }
}
