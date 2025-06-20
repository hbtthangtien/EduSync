using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_numberOfSlotInCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "DurationSession",
                table: "Courses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSession",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DurationSession", "NumberOfSession" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationSession",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NumberOfSession",
                table: "Courses");
        }
    }
}
