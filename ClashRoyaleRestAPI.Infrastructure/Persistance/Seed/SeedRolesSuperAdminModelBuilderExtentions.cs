using ClashRoyaleRestAPI.Application.Auth.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Seed;

public static class SeedRolesSuperAdminModelBuilderExtentions
{
    public static void SeedRoles(this ModelBuilder builder, string superAdminPSW)
    {

        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id = "6c0323e9-817c-4d08-b0bc-90fbddf598ee",
                Name = UserRoles.ADMIN,
                NormalizedName = UserRoles.ADMIN.ToUpper(),
                ConcurrencyStamp = "5bff1bbe-f340-4c82-9586-2f0dcc1e73c0",
            },
            new IdentityRole
            {
                Id = "e58b0a8c-8656-463d-8e43-de571a5394ca",
                Name = UserRoles.USER,
                NormalizedName = UserRoles.USER.ToUpper(),
                ConcurrencyStamp = "7f8b6799-7075-4b2a-9f19-edb6c5c0610e",
            },
            new IdentityRole
            {
                Id="b82604fe-f635-478d-a1b9-07ee8a2ef13e",
                Name = UserRoles.SUPERADMIN,
                NormalizedName = UserRoles.SUPERADMIN.ToUpper(),
                ConcurrencyStamp = "bced0593-1c19-4305-8118-63fdd2f902fa"
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);

        var passwordHasher = new PasswordHasher<IdentityUser>();

        IdentityUser superadmin = new()
        {
            Id = "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e",
            UserName = "superadmin",
            NormalizedUserName = "SUPERADMIN",
            ConcurrencyStamp = "2138f6e3-9d68-4a9e-8f2e-986af2b353ea"
        };

        builder.Entity<IdentityUser>().HasData(superadmin);

        List<IdentityUserRole<string>> userRoles = new();

        superadmin.PasswordHash = passwordHasher.HashPassword(superadmin, superAdminPSW);

        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = superadmin.Id,
            RoleId = roles.First(q => q.Name == UserRoles.SUPERADMIN).Id
        });


        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

    }
}
