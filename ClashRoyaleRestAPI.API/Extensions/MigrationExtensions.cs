using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ClashRoyaleDbContext dbContext = scope.ServiceProvider.GetRequiredService<ClashRoyaleDbContext>();
        
        dbContext.Database.Migrate();
    }
}