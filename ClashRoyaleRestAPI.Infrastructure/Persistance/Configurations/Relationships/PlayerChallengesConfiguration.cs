using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships;

public class PlayerChallengesConfiguration : IEntityTypeConfiguration<PlayerChallengesModel>
{
    public void Configure(EntityTypeBuilder<PlayerChallengesModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => ValueObjectId.Create<PlayerChallengesId>(value));

        builder.Property<PlayerId>("PlayerId")
            .HasConversion(
                id => id.Value,
                value => ValueObjectId.Create<PlayerId>(value));

        builder.Property<ChallengeId>("ChallengeId")
            .HasConversion(
                id => id.Value, 
                value => ValueObjectId.Create<ChallengeId>(value));

        builder.HasOne(d => d.Player)
            .WithMany()
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Challenge)
            .WithMany()
            .HasForeignKey("ChallengeId");

        builder.HasIndex("PlayerId", "ChallengeId");
    }
}
