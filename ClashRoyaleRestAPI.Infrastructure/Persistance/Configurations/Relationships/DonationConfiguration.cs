using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships;

public class DonationConfiguration : IEntityTypeConfiguration<DonationModel>
{
    public void Configure(EntityTypeBuilder<DonationModel> builder)
    {
        builder.Property<PlayerId>("PlayerId")
            .HasConversion(
                id => id.Value,
                value => PlayerId.Create(value));

        builder.Property<ClanId>("ClanId")
            .HasConversion(
                id => id.Value,
                value => ClanId.Create(value));

        builder.Property<int>("CardId");

        builder.HasOne(d => d.Player)
            .WithMany()
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Clan)
            .WithMany()
            .HasForeignKey("ClanId");

        builder.HasOne(d => d.Card)
            .WithMany()
            .HasForeignKey("CardId");

        builder.Property(d => d.Date);

        builder.HasKey("PlayerId", "ClanId", "CardId", "Date");
    }
}
