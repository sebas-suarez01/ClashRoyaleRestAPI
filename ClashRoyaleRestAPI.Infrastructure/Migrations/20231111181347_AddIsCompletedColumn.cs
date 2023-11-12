using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCompletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "135710a2-f86b-413a-a03d-23e306bf2169");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1efdc548-7cc1-44e0-b984-bafb647e66d1");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2530f29d-c6ea-492a-8a26-cb9b4d9c8af2", "38f1346d-15cc-4066-92d1-7157adcb0d69" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2530f29d-c6ea-492a-8a26-cb9b4d9c8af2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "38f1346d-15cc-4066-92d1-7157adcb0d69");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "PlayerChallenges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "325ef2db-69ed-4f2d-b6dd-09c3b0f9da50", "dbfdf322-b1b1-492a-9773-94fa8fff3a6d", "User", "USER" },
                    { "bcbaa0ef-639f-461d-93f7-e2be80b98ca7", "dfddf6ae-8909-4d7f-a7eb-dd31bdaaac3e", "Admin", "ADMIN" },
                    { "d1f07830-952e-406a-8ba2-a3de145d90db", "b99c380e-de38-441a-98af-fa84243fca8e", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c1e9a06-b452-421b-a81a-7e283a3371f0", 0, "ef180189-5076-48cf-818d-1dc8b318ce38", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEFkQNd4ZjnG/9pJcIBHtNfS0xFnFItd2P3sxfmtGyLmOfKTZyQ3Qaz3q4H+PRwMByg==", null, false, "d849db8b-845f-46f9-bbcc-6ab27f049575", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d1f07830-952e-406a-8ba2-a3de145d90db", "0c1e9a06-b452-421b-a81a-7e283a3371f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "325ef2db-69ed-4f2d-b6dd-09c3b0f9da50");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bcbaa0ef-639f-461d-93f7-e2be80b98ca7");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d1f07830-952e-406a-8ba2-a3de145d90db", "0c1e9a06-b452-421b-a81a-7e283a3371f0" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d1f07830-952e-406a-8ba2-a3de145d90db");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0c1e9a06-b452-421b-a81a-7e283a3371f0");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "PlayerChallenges");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "135710a2-f86b-413a-a03d-23e306bf2169", "b8c7c4ef-6162-4e63-a560-44b13393e5f4", "Admin", "ADMIN" },
                    { "1efdc548-7cc1-44e0-b984-bafb647e66d1", "aadb9a88-cd2e-4b7b-acaa-d7424c7b16ac", "User", "USER" },
                    { "2530f29d-c6ea-492a-8a26-cb9b4d9c8af2", "5fb81ea3-9931-401b-adee-dc3ea68c6143", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38f1346d-15cc-4066-92d1-7157adcb0d69", 0, "6b5e1d4f-3a40-492b-94e0-ea4f2ff658c8", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAENr5BvsyGRxpCXRQWfGIfc77iRrEpTZxQSt61OxWVIb24TNlVr2OUxoHoIOxATIXgg==", null, false, "8bc6e838-5f88-43fe-8825-335dfa579f7e", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2530f29d-c6ea-492a-8a26-cb9b4d9c8af2", "38f1346d-15cc-4066-92d1-7157adcb0d69" });
        }
    }
}
