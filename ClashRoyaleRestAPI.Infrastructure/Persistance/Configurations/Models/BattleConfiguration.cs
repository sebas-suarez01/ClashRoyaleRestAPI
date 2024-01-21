using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Models;

public class BattleConfiguration : IEntityTypeConfiguration<BattleModel>
{
    public void Configure(EntityTypeBuilder<BattleModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property<PlayerId>("LoserId")
            .HasConversion(
                id => id.Value,
                value => PlayerId.Create(value))
            .IsRequired();

        builder.Property<PlayerId>("WinnerId")
            .HasConversion(
                id => id.Value,
                value => PlayerId.Create(value))
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
