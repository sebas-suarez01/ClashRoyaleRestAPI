using ClashRoyaleRestAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Models;

public class WarConfiguration : IEntityTypeConfiguration<WarModel>
{
    public void Configure(EntityTypeBuilder<WarModel> builder)
    {
        builder.HasKey(w => w.Id);
    }
}
