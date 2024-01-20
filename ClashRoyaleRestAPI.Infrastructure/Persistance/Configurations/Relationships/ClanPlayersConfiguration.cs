using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships;

public class ClanPlayersConfiguration : IEntityTypeConfiguration<ClanPlayersModel>
{
    public void Configure(EntityTypeBuilder<ClanPlayersModel> builder)
    {
        
        builder.Property<PlayerId>("PlayerId")
            .HasConversion(
                id => id.Value,
                value => PlayerId.Create(value));

        builder.Property<ClanId>("ClanId")
            .HasConversion(
                id => id.Value, 
                value => ClanId.Create(value));

        builder.HasKey("PlayerId", "ClanId");
        
        builder.HasOne(d => d.Clan)
            .WithMany(d => d.Players)
            .HasForeignKey("ClanId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Player)
            .WithMany()
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Cascade);


    }
}
