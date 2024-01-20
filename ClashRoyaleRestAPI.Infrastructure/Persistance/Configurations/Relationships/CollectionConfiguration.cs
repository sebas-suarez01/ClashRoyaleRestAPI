using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships;

public class CollectionConfiguration : IEntityTypeConfiguration<CollectionModel>
{
    public void Configure(EntityTypeBuilder<CollectionModel> builder)
    {
        builder.Property<PlayerId>("PlayerId")
            .HasConversion(
                id => id.Value,
                value => PlayerId.Create(value));

        builder.Property<int>("CardId");

        builder.HasOne(c => c.Player)
            .WithMany(p => p.Cards)
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Card)
            .WithMany()
            .HasForeignKey("CardId")
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasKey("PlayerId", "CardId");


    }
}
