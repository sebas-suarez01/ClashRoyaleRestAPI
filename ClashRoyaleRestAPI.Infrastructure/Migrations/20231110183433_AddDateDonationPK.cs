using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateDonationPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

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
                defaultValue: new DateTime(2023, 11, 10, 18, 34, 31, 858, DateTimeKind.Utc).AddTicks(4625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 8, 3, 9, 23, 179, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                columns: new[] { "PlayerId", "ClanId", "CardId", "Date" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f0ec5fb-4bad-42f9-b540-c887c1a26714", "86701646-0be9-4466-baa3-a1a163c86347", "User", "USER" },
                    { "703781a9-b703-437f-9607-8e29b8b7c503", "09067a1e-3773-4136-b441-61b645bcd109", "SuperAdmin", "SUPERADMIN" },
                    { "b818f905-286f-497c-932d-4162a4f4a06a", "59ec265a-ad01-4791-af92-dd3c8cfc0c4e", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7c508d5b-c0da-494f-8d79-450b9a6a0f37", 0, "e54bcd96-f98d-429a-9798-244c479a87f3", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEK61EyFElJeKNp8lzZn5MGuQ7jDqgMKkMI51DD6zl648wGoP2CrdrdxS3VuKl+Z3jQ==", null, false, "245b4a61-098a-4aa4-b1ba-da506545cb31", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "703781a9-b703-437f-9607-8e29b8b7c503", "7c508d5b-c0da-494f-8d79-450b9a6a0f37" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1f0ec5fb-4bad-42f9-b540-c887c1a26714");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b818f905-286f-497c-932d-4162a4f4a06a");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "703781a9-b703-437f-9607-8e29b8b7c503", "7c508d5b-c0da-494f-8d79-450b9a6a0f37" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "703781a9-b703-437f-9607-8e29b8b7c503");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c508d5b-c0da-494f-8d79-450b9a6a0f37");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 8, 3, 9, 23, 179, DateTimeKind.Utc).AddTicks(4110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 10, 18, 34, 31, 858, DateTimeKind.Utc).AddTicks(4625));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                columns: new[] { "PlayerId", "ClanId", "CardId" });

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
    }
}
