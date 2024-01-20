using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Models;

public class ChallengeConfiguration : IEntityTypeConfiguration<ChallengeModel>
{
    public void Configure(EntityTypeBuilder<ChallengeModel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ValueObjectId.Create<ChallengeId>(value));

        builder.Property(c => c.Name)
            .HasMaxLength(32)
            .IsRequired();
    }
}
