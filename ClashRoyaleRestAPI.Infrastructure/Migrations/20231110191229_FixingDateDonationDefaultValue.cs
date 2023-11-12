using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingDateDonationDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b4037b44-0315-4189-835b-88a5dc19ef97");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e8c3eb78-c8a1-4950-8af9-3d36791318c2");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3bd8243-0790-45e3-a265-4db5d3931485", "033e3531-afb6-4323-bd6c-e56e50c98357" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a3bd8243-0790-45e3-a265-4db5d3931485");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "033e3531-afb6-4323-bd6c-e56e50c98357");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 10, 13, 59, 32, 578, DateTimeKind.Local).AddTicks(4229));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 13, 59, 32, 578, DateTimeKind.Local).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3bd8243-0790-45e3-a265-4db5d3931485", "1fe19e90-acb9-4fbd-955d-4e36ccf0933f", "SuperAdmin", "SUPERADMIN" },
                    { "b4037b44-0315-4189-835b-88a5dc19ef97", "94e12573-c8cc-4167-8523-277428795704", "User", "USER" },
                    { "e8c3eb78-c8a1-4950-8af9-3d36791318c2", "afb096a7-1668-4c55-973a-35cf4c62b105", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "033e3531-afb6-4323-bd6c-e56e50c98357", 0, "5572ac71-1e3d-43cd-8da9-ff481d854ce9", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEDi3CuOn2A0ASqxDmbMvUCe4FdkIdDkypPKFrxwNs14+EL/VqvkFZfMdfn5FBkh2nQ==", null, false, "5be4d814-3334-4694-8089-c4a91b71ae80", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3bd8243-0790-45e3-a265-4db5d3931485", "033e3531-afb6-4323-bd6c-e56e50c98357" });
        }
    }
}
