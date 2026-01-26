using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_app.Migrations
{
    /// <inheritdoc />
    public partial class Indentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "r-admin", "STATIC_STAMP_123456", "Admin", "ADMIN" },
                    { "r-u1", "STATIC_STAMP_123456", "User", "USER" },
                    { "r-u2", "STATIC_STAMP_123456", "UserLevel2", "USERLEVEL2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "u-admin", 0, "STATIC_STAMP_123456", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@asp.app", true, null, false, null, "ADMIN@ASP.APP", "TOP1SERVER", "AQAAAAIAAYagAAAAEOf6Pb8v/8VwLIDv8T6/7UfVvJqR9Z0X5Y6vX5Y6vX", null, false, "STATIC_STAMP_123456", false, "Top1Server" },
                    { "u-host1", 0, "STATIC_STAMP_123456", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "host1@asp.app", true, null, false, null, "HOST1@ASP.APP", "HOST1", "AQAAAAIAAYagAAAAEOf6Pb8v/8VwLIDv8T6/7UfVvJqR9Z0X5Y6vX5Y6vX", null, false, "STATIC_STAMP_123456", false, "Host1" },
                    { "u-user1", 0, "STATIC_STAMP_123456", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user1@asp.app", true, null, false, null, "USER1@ASP.APP", "USER1", "AQAAAAIAAYagAAAAEOf6Pb8v/8VwLIDv8T6/7UfVvJqR9Z0X5Y6vX5Y6vX", null, false, "STATIC_STAMP_123456", false, "User1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "r-admin", "u-admin" },
                    { "r-u2", "u-host1" },
                    { "r-u1", "u-user1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "r-admin", "u-admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "r-u2", "u-host1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "r-u1", "u-user1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "r-admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "r-u1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "r-u2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u-admin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u-host1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u-user1");
        }
    }
}
