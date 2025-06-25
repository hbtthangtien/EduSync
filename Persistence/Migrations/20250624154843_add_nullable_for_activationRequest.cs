using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_nullable_for_activationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationRequests_Tutors_TutorUserId",
                table: "ActivationRequests");

            migrationBuilder.AlterColumn<long>(
                name: "TutorUserId",
                table: "ActivationRequests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationRequests_Tutors_TutorUserId",
                table: "ActivationRequests",
                column: "TutorUserId",
                principalTable: "Tutors",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationRequests_Tutors_TutorUserId",
                table: "ActivationRequests");

            migrationBuilder.AlterColumn<long>(
                name: "TutorUserId",
                table: "ActivationRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationRequests_Tutors_TutorUserId",
                table: "ActivationRequests",
                column: "TutorUserId",
                principalTable: "Tutors",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
