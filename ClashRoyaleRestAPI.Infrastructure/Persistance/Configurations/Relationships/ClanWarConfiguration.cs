using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships;

public class ClanWarsConfiguration : IEntityTypeConfiguration<ClanWarsModel>
{
    public void Configure(EntityTypeBuilder<ClanWarsModel> builder)
    {
        builder.Property<WarId>("WarId")
            .HasConversion(
                id => id.Value,
                value => WarId.Create(value));
        builder.Property<ClanId>("ClanId")
            .HasConversion(
                id => id.Value,
                value => ClanId.Create(value));

        builder.HasKey("ClanId", "WarId");
        
        builder.HasOne(c => c.War)
            .WithMany()
            .HasForeignKey("WarId");
        
        builder.HasOne(c => c.Clan)
            .WithMany()
            .HasForeignKey("ClanId");

    }
}
