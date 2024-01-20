using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c0323e9-817c-4d08-b0bc-90fbddf598ee", "5bff1bbe-f340-4c82-9586-2f0dcc1e73c0", "Admin", "ADMIN" },
                    { "b82604fe-f635-478d-a1b9-07ee8a2ef13e", "bced0593-1c19-4305-8118-63fdd2f902fa", "SuperAdmin", "SUPERADMIN" },
                    { "e58b0a8c-8656-463d-8e43-de571a5394ca", "7f8b6799-7075-4b2a-9f19-edb6c5c0610e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e", 0, "2138f6e3-9d68-4a9e-8f2e-986af2b353ea", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEP1x2wKjYpuFJQ0vMhvvTqGNxH7FIqPasocUtJx7b2N2NX8qOKLtbkkqnmyo9RTDvw==", null, false, "f14b5b42-2cf8-43c8-be09-10dc37af037c", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b82604fe-f635-478d-a1b9-07ee8a2ef13e", "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6c0323e9-817c-4d08-b0bc-90fbddf598ee");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e58b0a8c-8656-463d-8e43-de571a5394ca");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b82604fe-f635-478d-a1b9-07ee8a2ef13e", "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b82604fe-f635-478d-a1b9-07ee8a2ef13e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e");
        }
    }
}
