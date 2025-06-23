using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class back_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleTimes");

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

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "WeeklySchedules",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SlotId",
                table: "WeeklySchedules",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_CourseId",
                table: "WeeklySchedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_SlotId",
                table: "WeeklySchedules",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklySchedules_Courses_CourseId",
                table: "WeeklySchedules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklySchedules_Slots_SlotId",
                table: "WeeklySchedules",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklySchedules_Courses_CourseId",
                table: "WeeklySchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklySchedules_Slots_SlotId",
                table: "WeeklySchedules");

            migrationBuilder.DropIndex(
                name: "IX_WeeklySchedules_CourseId",
                table: "WeeklySchedules");

            migrationBuilder.DropIndex(
                name: "IX_WeeklySchedules_SlotId",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "WeeklySchedules");

            migrationBuilder.CreateTable(
                name: "ScheduleTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    SlotId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeeklySchedulesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleTimes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleTimes_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleTimes_WeeklySchedules_WeeklySchedulesId",
                        column: x => x.WeeklySchedulesId,
                        principalTable: "WeeklySchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimes_CourseId",
                table: "ScheduleTimes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimes_SlotId",
                table: "ScheduleTimes",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimes_WeeklySchedulesId",
                table: "ScheduleTimes",
                column: "WeeklySchedulesId");
        }
    }
}
