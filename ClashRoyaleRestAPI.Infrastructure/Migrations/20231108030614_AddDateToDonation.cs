using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToDonation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "768d8b2c-22a2-49aa-9061-45d2921734d1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d0c478ba-2313-43e9-a94c-03b6f42ca188");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5fda05f7-5c94-435e-8f07-d59190ef951e", "d70a584a-77c8-43d0-b028-823142e2a52d" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5fda05f7-5c94-435e-8f07-d59190ef951e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d70a584a-77c8-43d0-b028-823142e2a52d");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Donations");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fda05f7-5c94-435e-8f07-d59190ef951e", "f9daa04b-91a6-4a41-adec-af1723c6346d", "SuperAdmin", "SUPERADMIN" },
                    { "768d8b2c-22a2-49aa-9061-45d2921734d1", "d2bde979-e968-4b7f-8b74-8814917c55f9", "User", "USER" },
                    { "d0c478ba-2313-43e9-a94c-03b6f42ca188", "909bf57d-45e0-4213-a194-d2c2362e137b", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d70a584a-77c8-43d0-b028-823142e2a52d", 0, "c78bdabf-4fb5-4af0-90ec-bcaf0b6dd72e", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAED0wNl2Z2k836nnqv2EN2VaBzyGRCVmbXGRe8HpIJPep8wtx/9NASKfxqpOPHmFPjA==", null, false, "28be274d-dcfb-4771-b0ce-9f28e2657efa", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5fda05f7-5c94-435e-8f07-d59190ef951e", "d70a584a-77c8-43d0-b028-823142e2a52d" });
        }
    }
}
