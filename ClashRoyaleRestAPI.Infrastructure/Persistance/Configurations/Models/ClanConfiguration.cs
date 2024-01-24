using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Models;

public class ClanConfiguration : IEntityTypeConfiguration<ClanModel>
{
    public void Configure(EntityTypeBuilder<ClanModel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ValueObjectId.Create<ClanId>(value));

        builder.Property(c => c.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(c => c.Region)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(c => c.TrophiesInWar)
            .HasDefaultValue(0);

        builder.Property(c => c.AmountMembers)
            .HasDefaultValue(0);

        builder.Property(c => c.MinTrophies)
            .HasDefaultValue(0);

        var nav = builder.Metadata.FindNavigation(nameof(ClanModel.Players));

        nav!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
