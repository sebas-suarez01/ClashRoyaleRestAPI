using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6a2bf723-f147-45b6-94de-1e392c9b2c3a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ada81d47-64ae-4879-895d-e2124450cd91");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e84cd157-9b7c-4745-bd46-6ffeb84d2a2c", "36e64893-7ec0-44c4-adeb-a7dc7d1604cd" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e84cd157-9b7c-4745-bd46-6ffeb84d2a2c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "36e64893-7ec0-44c4-adeb-a7dc7d1604cd");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a2bf723-f147-45b6-94de-1e392c9b2c3a", "de73eb1d-575f-475a-b079-2c3dadf6c4ef", "Admin", "ADMIN" },
                    { "ada81d47-64ae-4879-895d-e2124450cd91", "ee19b44a-f0b5-44c0-b09e-4a696d8cccdc", "User", "USER" },
                    { "e84cd157-9b7c-4745-bd46-6ffeb84d2a2c", "e1ca2c3c-7309-4d53-9ce2-01fd5e7c8a15", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "36e64893-7ec0-44c4-adeb-a7dc7d1604cd", 0, "2b7a96b0-8831-4cb5-9b62-6f91bd99c65a", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEOrSJgIQdYkcwIVeq1jhBOc+dX46LVf68T+sibVW6Hg90psm0wZPJXhPolxHbNyW/g==", null, false, "ac5ed362-0529-4420-90f1-57453e36e096", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e84cd157-9b7c-4745-bd46-6ffeb84d2a2c", "36e64893-7ec0-44c4-adeb-a7dc7d1604cd" });
        }
    }
}
