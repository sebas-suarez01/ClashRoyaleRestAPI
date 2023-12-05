using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Models;

public class BattleConfiguration : IEntityTypeConfiguration<BattleModel>
{
    public void Configure(EntityTypeBuilder<BattleModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property<int>("LoserId")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property<int>("WinnerId")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BattleId.Create(value));

        builder.HasOne(b => b.Loser)
            .WithMany()
            .HasForeignKey("LoserId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(b => b.Winner)
            .WithMany()
            .HasForeignKey("WinnerId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex("WinnerId", "LoserId", "Date").IsUnique();
    }
}
