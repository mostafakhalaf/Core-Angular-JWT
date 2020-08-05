using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MostafaKhalafFullStack.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "964063db-04a2-481c-b387-9e2031e0066a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa98d02c-debb-4f0e-80a7-a021f74201c8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a501305-4fb3-4a83-a3d4-dbcd34a4fa96", 0, 25, new DateTime(2020, 7, 31, 18, 47, 6, 393, DateTimeKind.Local).AddTicks(36), "c8d89e4a-4e06-4652-8479-4405f1fa62ee", null, false, "mostafakhalaf", "male", false, null, null, null, null, null, false, null, false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "27d3adcb-1984-461b-b50f-6f818fbc0ab2", 0, 25, new DateTime(2020, 7, 31, 18, 47, 6, 394, DateTimeKind.Local).AddTicks(6099), "07806707-f7d2-4587-8739-95147503491b", null, false, "htem", "female", false, null, null, null, null, null, false, null, false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d3adcb-1984-461b-b50f-6f818fbc0ab2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a501305-4fb3-4a83-a3d4-dbcd34a4fa96");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "964063db-04a2-481c-b387-9e2031e0066a", 0, 25, new DateTime(2020, 7, 28, 7, 4, 52, 979, DateTimeKind.Local).AddTicks(2112), "338c882b-192c-483a-9a15-f8e805821581", null, false, "mostafakhalaf", "male", false, null, null, null, null, null, false, null, false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa98d02c-debb-4f0e-80a7-a021f74201c8", 0, 25, new DateTime(2020, 7, 28, 7, 4, 53, 19, DateTimeKind.Local).AddTicks(6628), "20bfc3c9-19b7-4d04-9dd0-88e734e8bde1", null, false, "htem", "female", false, null, null, null, null, null, false, null, false, null });
        }
    }
}
