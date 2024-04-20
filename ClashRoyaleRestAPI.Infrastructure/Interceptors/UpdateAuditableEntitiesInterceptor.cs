using ClashRoyaleRestAPI.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ClashRoyaleRestAPI.Infrastructure.Interceptors;

public class UpdateAuditableEntitiesInterceptor: SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;

        if(context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var entries = context
            .ChangeTracker
            .Entries<IAuditableEntity>();

        foreach (var entry in entries)
        {
            if(entry.State == EntityState.Added) 
            {
                entry.Property(e=> e.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
            }

            if(entry.State == EntityState.Modified)
            {
                entry.Property(e => e.ModifiedOnUtc).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
