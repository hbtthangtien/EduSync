using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeding_weeklyschedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeeklySchedules",
                columns: new[] { "Id", "CreatedAt", "DayOfWeek", "DeletedAt", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null },
                    { 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, null },
                    { 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, null },
                    { 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, null },
                    { 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null, null },
                    { 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null, null },
                    { 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeeklySchedules",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "WeeklySchedules",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "WeeklySchedules",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "WeeklySchedules",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "WeeklySchedules",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "WeeklySchedules",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "WeeklySchedules",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
