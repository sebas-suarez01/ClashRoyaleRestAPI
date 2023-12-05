using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships;

public class DonationConfiguration : IEntityTypeConfiguration<DonationModel>
{
    public void Configure(EntityTypeBuilder<DonationModel> builder)
    {
        builder.Property<int>("PlayerId");
        builder.Property<int>("ClanId");
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
