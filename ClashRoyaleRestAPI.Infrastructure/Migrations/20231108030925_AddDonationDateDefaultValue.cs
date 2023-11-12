using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDonationDateDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1458efc0-5930-41e2-bdd5-cfa9e3b3e939");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "49d10e87-6bff-4aba-8a49-2ff63cc45901");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e94f639-4401-4d0c-bcb7-761d95b2352b", "f1bf3761-69a0-4b2a-9e1a-5b41e16ded16" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2e94f639-4401-4d0c-bcb7-761d95b2352b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f1bf3761-69a0-4b2a-9e1a-5b41e16ded16");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 8, 3, 9, 23, 179, DateTimeKind.Utc).AddTicks(4110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81207348-962f-44cb-9496-34ad64e20fcf", "ec2f3d12-5b87-4cb2-8f13-e2f34d05ecec", "SuperAdmin", "SUPERADMIN" },
                    { "91fabd8c-1237-456b-aefe-3adb29b10a22", "003af40b-6b12-4bd5-a2ec-aa7f26b30101", "User", "USER" },
                    { "9bea2e59-6b07-4e4e-8c89-160a5a5b7612", "08eb71b0-8ebf-495e-83ba-d4c74e3e3e6b", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "54e08bab-0f9f-4ad9-94e3-4ae78543bf95", 0, "7052bc9f-c043-4257-a812-186c584951fe", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEHK93oCdPbf85rLrC3pzLUgk4bi0/vdmGFasxUaemcWFAM436mJk/QU2YJN+IamisA==", null, false, "52e38ea0-daa2-4bd8-b88e-41f44270d2a7", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81207348-962f-44cb-9496-34ad64e20fcf", "54e08bab-0f9f-4ad9-94e3-4ae78543bf95" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "91fabd8c-1237-456b-aefe-3adb29b10a22");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9bea2e59-6b07-4e4e-8c89-160a5a5b7612");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81207348-962f-44cb-9496-34ad64e20fcf", "54e08bab-0f9f-4ad9-94e3-4ae78543bf95" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "81207348-962f-44cb-9496-34ad64e20fcf");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "54e08bab-0f9f-4ad9-94e3-4ae78543bf95");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 8, 3, 9, 23, 179, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1458efc0-5930-41e2-bdd5-cfa9e3b3e939", "33ed8b85-8343-4e66-bb32-bb0657e0ff52", "Admin", "ADMIN" },
                    { "2e94f639-4401-4d0c-bcb7-761d95b2352b", "6033fe17-68ce-4df6-8ee4-2d7b68f41bbe", "SuperAdmin", "SUPERADMIN" },
                    { "49d10e87-6bff-4aba-8a49-2ff63cc45901", "04d5833a-7275-4d8a-8785-adeaaca2283b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f1bf3761-69a0-4b2a-9e1a-5b41e16ded16", 0, "5f9b7a1b-e736-4d0e-a007-efb35d36e116", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEFLi5cteTZdvFETMzGyQKUFvSqdzReXLqLE+1+rXtztHZNaN2bRnraAs6IA+Ly4rMg==", null, false, "26411e8b-3dbd-481c-acc3-d1a6e4524f82", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2e94f639-4401-4d0c-bcb7-761d95b2352b", "f1bf3761-69a0-4b2a-9e1a-5b41e16ded16" });
        }
    }
}
