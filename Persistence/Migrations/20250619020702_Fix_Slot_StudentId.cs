using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Slot_StudentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Courses_CourseId",
                table: "Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Students_StudentId",
                table: "Slots");

            migrationBuilder.AddColumn<long>(
                name: "TutorUserId",
                table: "Students",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TutorUserId",
                table: "Students",
                column: "TutorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Courses_CourseId",
                table: "Slots",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Students_StudentId",
                table: "Slots",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tutors_TutorUserId",
                table: "Students",
                column: "TutorUserId",
                principalTable: "Tutors",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Courses_CourseId",
                table: "Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Students_StudentId",
                table: "Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tutors_TutorUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TutorUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TutorUserId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Courses_CourseId",
                table: "Slots",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Students_StudentId",
                table: "Slots",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId");
        }
    }
}
