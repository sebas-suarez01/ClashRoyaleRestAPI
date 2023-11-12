using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateDonationDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "10ab4953-517f-4a85-a8bf-2a26394a2923");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8dd87819-b499-4b1f-8bd1-9c30ccc18da2");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c051873-ddc9-4b5b-8480-ab4ce4a7e4f5", "30deb8cd-0fb6-4b83-be81-3d4426cbe439" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3c051873-ddc9-4b5b-8480-ab4ce4a7e4f5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "30deb8cd-0fb6-4b83-be81-3d4426cbe439");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 13, 59, 32, 578, DateTimeKind.Local).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 10, 13, 57, 10, 254, DateTimeKind.Local).AddTicks(7845));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 11, 10, 13, 57, 10, 254, DateTimeKind.Local).AddTicks(7845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 10, 13, 59, 32, 578, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10ab4953-517f-4a85-a8bf-2a26394a2923", "af6aae93-2ced-4d81-a2f5-0088a68e7a9f", "Admin", "ADMIN" },
                    { "3c051873-ddc9-4b5b-8480-ab4ce4a7e4f5", "07d4e14f-7993-4fe8-8b71-c3ddaa02633a", "SuperAdmin", "SUPERADMIN" },
                    { "8dd87819-b499-4b1f-8bd1-9c30ccc18da2", "f53d4e7c-ce1f-4e4f-b44f-964e0b51e83f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "30deb8cd-0fb6-4b83-be81-3d4426cbe439", 0, "0962159f-40c7-4915-92d7-439249ad4da6", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEHyO1vPsKjDoHnCOrByov/5b8nJkhyjjbsXhLXMf3U5zEGiPW+Hq/hTnMsG6ODjRQA==", null, false, "88c82d68-045f-4c63-b19b-11746ebfdcdf", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3c051873-ddc9-4b5b-8480-ab4ce4a7e4f5", "30deb8cd-0fb6-4b83-be81-3d4426cbe439" });
        }
    }
}
