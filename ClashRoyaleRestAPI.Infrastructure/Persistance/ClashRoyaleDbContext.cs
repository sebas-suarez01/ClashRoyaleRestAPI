using ClashRoyaleRestAPI.Domain.Common.Relationships;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Card.Implementation;
using ClashRoyaleRestAPI.Domain.Models.Challenge;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Models.War;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Models;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance
{
    public class ClashRoyaleDbContext : DbContext
    {
        public ClashRoyaleDbContext(DbContextOptions<ClashRoyaleDbContext> options) : base(options) { }

        public DbSet<BattleModel> Battles => Set<BattleModel>();
        public DbSet<CardModel> Cards => Set<CardModel>();
        public DbSet<ChallengeModel> Challenges => Set<ChallengeModel>();
        public DbSet<ClanModel> Clans => Set<ClanModel>();
        public DbSet<ClanWarsModel> ClanWars => Set<ClanWarsModel>();
        public DbSet<CollectionModel> Collection => Set<CollectionModel>();
        public DbSet<DonationModel> Donations => Set<DonationModel>();
        public DbSet<PlayerChallengesModel> PlayerChallenges => Set<PlayerChallengesModel>();
        public DbSet<ClanPlayersModel> PlayerClans => Set<ClanPlayersModel>();
        public DbSet<PlayerModel> Players => Set<PlayerModel>();
        public DbSet<SpellModel> Spells => Set<SpellModel>();
        public DbSet<StructureModel> Structures => Set<StructureModel>();
        public DbSet<TroopModel> Troops => Set<TroopModel>();
        public DbSet<WarModel> Wars => Set<WarModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            ApplyModelsConfiguration(modelBuilder);
            ApplyRelationshipsConfiguration(modelBuilder);

            modelBuilder.SeedCards();

        }
        private void ApplyRelationshipsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanWarsConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollectionConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonationConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerChallengesConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanPlayersConfiguration).Assembly);
        }

        private void ApplyModelsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BattleConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TroopConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpellConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StructureConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarConfiguration).Assembly);
        }
    }
}
