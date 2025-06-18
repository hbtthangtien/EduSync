using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixstudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Tutors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BioTutor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorId = table.Column<long>(type: "bigint", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specializations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introduces = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioTutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BioTutor_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByTutorId = table.Column<long>(type: "bigint", nullable: false),
                    IsTrialAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TrialSessions = table.Column<long>(type: "bigint", nullable: false),
                    PricePerSession = table.Column<double>(type: "float", nullable: false),
                    ServiceFeePercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Tutors_CreatedByTutorId",
                        column: x => x.CreatedByTutorId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivationRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivationRequests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivationRequests_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseCancellations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRefunded = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCancellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCancellations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCancellations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    TutorId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfSlot = table.Column<short>(type: "smallint", nullable: false),
                    DurationSession = table.Column<long>(type: "bigint", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    IsTrial = table.Column<bool>(type: "bit", nullable: false),
                    MeetUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slots_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slots_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Slots_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: true),
                    CourseCancellationId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_CourseCancellations_CourseCancellationId",
                        column: x => x.CourseCancellationId,
                        principalTable: "CourseCancellations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklySchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    SlotId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklySchedules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklySchedules_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "Tutor", new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "Student", new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "PasswordHash", "RoleId", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[] { 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "tutor1@example.com", "Password123@", 2L, null, null, "tutor1" });

            migrationBuilder.InsertData(
                table: "Tutors",
                columns: new[] { "UserId", "CreatedAt", "DeletedAt", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null, null });

            migrationBuilder.InsertData(
                table: "BioTutor",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Fullname", "Introduces", "Specializations", "TutorId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bùi Đức Tùng", "Tôi là bậc thầy IELTS", "IELTS", 1L, null, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "CreatedByTutorId", "DeletedAt", "Description", "IsTrialAvailable", "PricePerSession", "ServiceFeePercentage", "Status", "Title", "TrialSessions", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 1", 2L, null, null },
                    { 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 2", 2L, null, null },
                    { 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 3", 2L, null, null },
                    { 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 4", 2L, null, null },
                    { 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 5", 2L, null, null },
                    { 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 6", 2L, null, null },
                    { 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 7", 2L, null, null },
                    { 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 8", 2L, null, null },
                    { 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 9", 2L, null, null },
                    { 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.", true, 150.0, 10m, 4, "IELTS Preparation Course 10", 2L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "ContentType", "CourseId", "CreatedAt", "DeletedAt", "Descriptions", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 1.", null, null },
                    { 2L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 1.", null, null },
                    { 3L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 1.", null, null },
                    { 4L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 1.", null, null },
                    { 5L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 1.", null, null },
                    { 6L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 1.", null, null },
                    { 7L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 1.", null, null },
                    { 8L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 1.", null, null },
                    { 9L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 1.", null, null },
                    { 10L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 1.", null, null },
                    { 11L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 1.", null, null },
                    { 12L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 1.", null, null },
                    { 13L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 1.", null, null },
                    { 14L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 1.", null, null },
                    { 15L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 1.", null, null },
                    { 16L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 1.", null, null },
                    { 17L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 1.", null, null },
                    { 18L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 1.", null, null },
                    { 19L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 1.", null, null },
                    { 20L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 1.", null, null },
                    { 21L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 1.", null, null },
                    { 22L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 1.", null, null },
                    { 23L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 1.", null, null },
                    { 24L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 1.", null, null },
                    { 25L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 1.", null, null },
                    { 26L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 1.", null, null },
                    { 27L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 1.", null, null },
                    { 28L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 1.", null, null },
                    { 29L, "Video", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 1.", null, null },
                    { 30L, "Document", 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 1.", null, null },
                    { 31L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 2.", null, null },
                    { 32L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 2.", null, null },
                    { 33L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 2.", null, null },
                    { 34L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 2.", null, null },
                    { 35L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 2.", null, null },
                    { 36L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 2.", null, null },
                    { 37L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 2.", null, null },
                    { 38L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 2.", null, null },
                    { 39L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 2.", null, null },
                    { 40L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 2.", null, null },
                    { 41L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 2.", null, null },
                    { 42L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 2.", null, null },
                    { 43L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 2.", null, null },
                    { 44L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 2.", null, null },
                    { 45L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 2.", null, null },
                    { 46L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 2.", null, null },
                    { 47L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 2.", null, null },
                    { 48L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 2.", null, null },
                    { 49L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 2.", null, null },
                    { 50L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 2.", null, null },
                    { 51L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 2.", null, null },
                    { 52L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 2.", null, null },
                    { 53L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 2.", null, null },
                    { 54L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 2.", null, null },
                    { 55L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 2.", null, null },
                    { 56L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 2.", null, null },
                    { 57L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 2.", null, null },
                    { 58L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 2.", null, null },
                    { 59L, "Video", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 2.", null, null },
                    { 60L, "Document", 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 2.", null, null },
                    { 61L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 3.", null, null },
                    { 62L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 3.", null, null },
                    { 63L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 3.", null, null },
                    { 64L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 3.", null, null },
                    { 65L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 3.", null, null },
                    { 66L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 3.", null, null },
                    { 67L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 3.", null, null },
                    { 68L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 3.", null, null },
                    { 69L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 3.", null, null },
                    { 70L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 3.", null, null },
                    { 71L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 3.", null, null },
                    { 72L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 3.", null, null },
                    { 73L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 3.", null, null },
                    { 74L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 3.", null, null },
                    { 75L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 3.", null, null },
                    { 76L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 3.", null, null },
                    { 77L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 3.", null, null },
                    { 78L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 3.", null, null },
                    { 79L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 3.", null, null },
                    { 80L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 3.", null, null },
                    { 81L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 3.", null, null },
                    { 82L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 3.", null, null },
                    { 83L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 3.", null, null },
                    { 84L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 3.", null, null },
                    { 85L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 3.", null, null },
                    { 86L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 3.", null, null },
                    { 87L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 3.", null, null },
                    { 88L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 3.", null, null },
                    { 89L, "Video", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 3.", null, null },
                    { 90L, "Document", 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 3.", null, null },
                    { 91L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 4.", null, null },
                    { 92L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 4.", null, null },
                    { 93L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 4.", null, null },
                    { 94L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 4.", null, null },
                    { 95L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 4.", null, null },
                    { 96L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 4.", null, null },
                    { 97L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 4.", null, null },
                    { 98L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 4.", null, null },
                    { 99L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 4.", null, null },
                    { 100L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 4.", null, null },
                    { 101L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 4.", null, null },
                    { 102L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 4.", null, null },
                    { 103L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 4.", null, null },
                    { 104L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 4.", null, null },
                    { 105L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 4.", null, null },
                    { 106L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 4.", null, null },
                    { 107L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 4.", null, null },
                    { 108L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 4.", null, null },
                    { 109L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 4.", null, null },
                    { 110L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 4.", null, null },
                    { 111L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 4.", null, null },
                    { 112L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 4.", null, null },
                    { 113L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 4.", null, null },
                    { 114L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 4.", null, null },
                    { 115L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 4.", null, null },
                    { 116L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 4.", null, null },
                    { 117L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 4.", null, null },
                    { 118L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 4.", null, null },
                    { 119L, "Video", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 4.", null, null },
                    { 120L, "Document", 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 4.", null, null },
                    { 121L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 5.", null, null },
                    { 122L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 5.", null, null },
                    { 123L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 5.", null, null },
                    { 124L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 5.", null, null },
                    { 125L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 5.", null, null },
                    { 126L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 5.", null, null },
                    { 127L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 5.", null, null },
                    { 128L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 5.", null, null },
                    { 129L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 5.", null, null },
                    { 130L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 5.", null, null },
                    { 131L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 5.", null, null },
                    { 132L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 5.", null, null },
                    { 133L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 5.", null, null },
                    { 134L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 5.", null, null },
                    { 135L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 5.", null, null },
                    { 136L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 5.", null, null },
                    { 137L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 5.", null, null },
                    { 138L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 5.", null, null },
                    { 139L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 5.", null, null },
                    { 140L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 5.", null, null },
                    { 141L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 5.", null, null },
                    { 142L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 5.", null, null },
                    { 143L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 5.", null, null },
                    { 144L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 5.", null, null },
                    { 145L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 5.", null, null },
                    { 146L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 5.", null, null },
                    { 147L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 5.", null, null },
                    { 148L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 5.", null, null },
                    { 149L, "Video", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 5.", null, null },
                    { 150L, "Document", 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 5.", null, null },
                    { 151L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 6.", null, null },
                    { 152L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 6.", null, null },
                    { 153L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 6.", null, null },
                    { 154L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 6.", null, null },
                    { 155L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 6.", null, null },
                    { 156L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 6.", null, null },
                    { 157L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 6.", null, null },
                    { 158L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 6.", null, null },
                    { 159L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 6.", null, null },
                    { 160L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 6.", null, null },
                    { 161L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 6.", null, null },
                    { 162L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 6.", null, null },
                    { 163L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 6.", null, null },
                    { 164L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 6.", null, null },
                    { 165L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 6.", null, null },
                    { 166L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 6.", null, null },
                    { 167L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 6.", null, null },
                    { 168L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 6.", null, null },
                    { 169L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 6.", null, null },
                    { 170L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 6.", null, null },
                    { 171L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 6.", null, null },
                    { 172L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 6.", null, null },
                    { 173L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 6.", null, null },
                    { 174L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 6.", null, null },
                    { 175L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 6.", null, null },
                    { 176L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 6.", null, null },
                    { 177L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 6.", null, null },
                    { 178L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 6.", null, null },
                    { 179L, "Video", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 6.", null, null },
                    { 180L, "Document", 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 6.", null, null },
                    { 181L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 7.", null, null },
                    { 182L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 7.", null, null },
                    { 183L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 7.", null, null },
                    { 184L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 7.", null, null },
                    { 185L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 7.", null, null },
                    { 186L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 7.", null, null },
                    { 187L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 7.", null, null },
                    { 188L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 7.", null, null },
                    { 189L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 7.", null, null },
                    { 190L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 7.", null, null },
                    { 191L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 7.", null, null },
                    { 192L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 7.", null, null },
                    { 193L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 7.", null, null },
                    { 194L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 7.", null, null },
                    { 195L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 7.", null, null },
                    { 196L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 7.", null, null },
                    { 197L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 7.", null, null },
                    { 198L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 7.", null, null },
                    { 199L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 7.", null, null },
                    { 200L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 7.", null, null },
                    { 201L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 7.", null, null },
                    { 202L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 7.", null, null },
                    { 203L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 7.", null, null },
                    { 204L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 7.", null, null },
                    { 205L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 7.", null, null },
                    { 206L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 7.", null, null },
                    { 207L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 7.", null, null },
                    { 208L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 7.", null, null },
                    { 209L, "Video", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 7.", null, null },
                    { 210L, "Document", 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 7.", null, null },
                    { 211L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 8.", null, null },
                    { 212L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 8.", null, null },
                    { 213L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 8.", null, null },
                    { 214L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 8.", null, null },
                    { 215L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 8.", null, null },
                    { 216L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 8.", null, null },
                    { 217L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 8.", null, null },
                    { 218L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 8.", null, null },
                    { 219L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 8.", null, null },
                    { 220L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 8.", null, null },
                    { 221L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 8.", null, null },
                    { 222L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 8.", null, null },
                    { 223L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 8.", null, null },
                    { 224L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 8.", null, null },
                    { 225L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 8.", null, null },
                    { 226L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 8.", null, null },
                    { 227L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 8.", null, null },
                    { 228L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 8.", null, null },
                    { 229L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 8.", null, null },
                    { 230L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 8.", null, null },
                    { 231L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 8.", null, null },
                    { 232L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 8.", null, null },
                    { 233L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 8.", null, null },
                    { 234L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 8.", null, null },
                    { 235L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 8.", null, null },
                    { 236L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 8.", null, null },
                    { 237L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 8.", null, null },
                    { 238L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 8.", null, null },
                    { 239L, "Video", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 8.", null, null },
                    { 240L, "Document", 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 8.", null, null },
                    { 241L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 9.", null, null },
                    { 242L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 9.", null, null },
                    { 243L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 9.", null, null },
                    { 244L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 9.", null, null },
                    { 245L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 9.", null, null },
                    { 246L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 9.", null, null },
                    { 247L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 9.", null, null },
                    { 248L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 9.", null, null },
                    { 249L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 9.", null, null },
                    { 250L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 9.", null, null },
                    { 251L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 9.", null, null },
                    { 252L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 9.", null, null },
                    { 253L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 9.", null, null },
                    { 254L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 9.", null, null },
                    { 255L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 9.", null, null },
                    { 256L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 9.", null, null },
                    { 257L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 9.", null, null },
                    { 258L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 9.", null, null },
                    { 259L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 9.", null, null },
                    { 260L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 9.", null, null },
                    { 261L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 9.", null, null },
                    { 262L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 9.", null, null },
                    { 263L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 9.", null, null },
                    { 264L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 9.", null, null },
                    { 265L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 9.", null, null },
                    { 266L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 9.", null, null },
                    { 267L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 9.", null, null },
                    { 268L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 9.", null, null },
                    { 269L, "Video", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 9.", null, null },
                    { 270L, "Document", 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 9.", null, null },
                    { 271L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 1 for Course 10.", null, null },
                    { 272L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 2 for Course 10.", null, null },
                    { 273L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 3 for Course 10.", null, null },
                    { 274L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 4 for Course 10.", null, null },
                    { 275L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 5 for Course 10.", null, null },
                    { 276L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 6 for Course 10.", null, null },
                    { 277L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 7 for Course 10.", null, null },
                    { 278L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 8 for Course 10.", null, null },
                    { 279L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 9 for Course 10.", null, null },
                    { 280L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 10 for Course 10.", null, null },
                    { 281L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 11 for Course 10.", null, null },
                    { 282L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 12 for Course 10.", null, null },
                    { 283L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 13 for Course 10.", null, null },
                    { 284L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 14 for Course 10.", null, null },
                    { 285L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 15 for Course 10.", null, null },
                    { 286L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 16 for Course 10.", null, null },
                    { 287L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 17 for Course 10.", null, null },
                    { 288L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 18 for Course 10.", null, null },
                    { 289L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 19 for Course 10.", null, null },
                    { 290L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 20 for Course 10.", null, null },
                    { 291L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 21 for Course 10.", null, null },
                    { 292L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 22 for Course 10.", null, null },
                    { 293L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 23 for Course 10.", null, null },
                    { 294L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 24 for Course 10.", null, null },
                    { 295L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 25 for Course 10.", null, null },
                    { 296L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 26 for Course 10.", null, null },
                    { 297L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 27 for Course 10.", null, null },
                    { 298L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 28 for Course 10.", null, null },
                    { 299L, "Video", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 29 for Course 10.", null, null },
                    { 300L, "Document", 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Lesson 30 for Course 10.", null, null }
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "CourseId", "CreatedAt", "DeletedAt", "DurationSession", "IsBooked", "IsTrial", "MeetUrl", "NumberOfSlot", "StudentId", "TutorId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-1-slot1", (short)1, null, 1L, null, null },
                    { 2L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-1-slot2", (short)1, null, 1L, null, null },
                    { 3L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-2-slot1", (short)1, null, 1L, null, null },
                    { 4L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-2-slot2", (short)1, null, 1L, null, null },
                    { 5L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-3-slot1", (short)1, null, 1L, null, null },
                    { 6L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-3-slot2", (short)1, null, 1L, null, null },
                    { 7L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-4-slot1", (short)1, null, 1L, null, null },
                    { 8L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-4-slot2", (short)1, null, 1L, null, null },
                    { 9L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-5-slot1", (short)1, null, 1L, null, null },
                    { 10L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-5-slot2", (short)1, null, 1L, null, null },
                    { 11L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-6-slot1", (short)1, null, 1L, null, null },
                    { 12L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-6-slot2", (short)1, null, 1L, null, null },
                    { 13L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-7-slot1", (short)1, null, 1L, null, null },
                    { 14L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-7-slot2", (short)1, null, 1L, null, null },
                    { 15L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-8-slot1", (short)1, null, 1L, null, null },
                    { 16L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-8-slot2", (short)1, null, 1L, null, null },
                    { 17L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-9-slot1", (short)1, null, 1L, null, null },
                    { 18L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-9-slot2", (short)1, null, 1L, null, null },
                    { 19L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, true, "https://meetlink.com/ielts-10-slot1", (short)1, null, 1L, null, null },
                    { 20L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 54000000000L, false, false, "https://meetlink.com/ielts-10-slot2", (short)1, null, 1L, null, null }
                });

            migrationBuilder.InsertData(
                table: "WeeklySchedules",
                columns: new[] { "Id", "CourseId", "CreatedAt", "DayOfWeek", "DeletedAt", "EndTime", "SlotId", "StartTime", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 4L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 5L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 6L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 7L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 8L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 9L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 10L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 11L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 12L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 13L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 14L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 15L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 16L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 17L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 18L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 19L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 20L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 21L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 22L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 23L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 24L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 25L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 26L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 27L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 28L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 29L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 30L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 31L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 32L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 33L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 34L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 35L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 36L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 37L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 38L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 39L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 40L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 41L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 42L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 43L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 44L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 45L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 46L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 47L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 48L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 49L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 50L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 51L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 52L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 53L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 54L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 55L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 56L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 57L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 58L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 59L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 60L, 1L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 61L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 62L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 63L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 64L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 65L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 66L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 67L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 68L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 69L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 70L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 71L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 72L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 73L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 74L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 75L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 76L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 77L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 78L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 79L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 80L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 81L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 82L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 83L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 84L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 85L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 86L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 87L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 88L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 89L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 90L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 91L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 92L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 93L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 94L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 95L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 96L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 97L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 98L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 99L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 100L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 101L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 102L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 103L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 104L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 105L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 106L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 107L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 108L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 109L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 110L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 111L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 112L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 113L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 114L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 115L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 116L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 117L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 118L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 119L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 120L, 2L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 121L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 122L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 123L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 124L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 125L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 126L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 127L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 128L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 129L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 130L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 131L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 132L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 133L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 134L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 135L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 136L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 137L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 138L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 139L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 140L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 141L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 142L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 143L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 144L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 145L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 146L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 147L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 148L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 149L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 150L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 151L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 152L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 153L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 154L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 155L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 156L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 157L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 158L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 159L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 160L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 161L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 162L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 163L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 164L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 165L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 166L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 167L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 168L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 169L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 170L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 171L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 172L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 173L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 174L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 175L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 176L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 177L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 178L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 179L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 180L, 3L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 181L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 182L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 183L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 184L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 185L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 186L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 187L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 188L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 189L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 190L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 191L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 192L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 193L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 194L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 195L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 196L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 197L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 198L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 199L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 200L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 201L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 202L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 203L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 204L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 205L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 206L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 207L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 208L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 209L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 210L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 211L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 212L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 213L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 214L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 215L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 216L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 217L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 218L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 219L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 220L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 221L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 222L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 223L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 224L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 225L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 226L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 227L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 228L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 229L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 230L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 231L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 232L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 233L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 234L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 235L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 236L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 237L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 238L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 239L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 240L, 4L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 8L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 241L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 242L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 243L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 244L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 245L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 246L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 247L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 248L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 249L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 250L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 251L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 252L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 253L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 254L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 255L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 256L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 257L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 258L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 259L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 260L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 261L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 262L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 263L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 264L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 265L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 266L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 267L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 268L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 269L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 270L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 9L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 271L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 272L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 273L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 274L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 275L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 276L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 277L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 278L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 279L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 280L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 281L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 282L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 283L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 284L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 285L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 286L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 287L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 288L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 289L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 290L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 291L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 292L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 293L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 294L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 295L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 296L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 297L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 298L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 299L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 300L, 5L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 10L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 301L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 302L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 303L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 304L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 305L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 306L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 307L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 308L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 309L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 310L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 311L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 312L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 313L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 314L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 315L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 316L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 317L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 318L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 319L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 320L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 321L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 322L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 323L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 324L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 325L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 326L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 327L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 328L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 329L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 330L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 11L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 331L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 332L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 333L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 334L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 335L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 336L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 337L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 338L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 339L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 340L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 341L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 342L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 343L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 344L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 345L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 346L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 347L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 348L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 349L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 350L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 351L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 352L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 353L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 354L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 355L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 356L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 357L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 358L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 359L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 360L, 6L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 361L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 362L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 363L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 364L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 365L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 366L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 367L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 368L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 369L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 370L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 371L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 372L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 373L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 374L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 375L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 376L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 377L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 378L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 379L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 380L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 381L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 382L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 383L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 384L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 385L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 386L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 387L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 388L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 389L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 390L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 13L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 391L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 392L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 393L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 394L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 395L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 396L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 397L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 398L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 399L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 400L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 401L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 402L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 403L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 404L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 405L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 406L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 407L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 408L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 409L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 410L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 411L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 412L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 413L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 414L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 415L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 416L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 417L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 418L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 419L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 420L, 7L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 14L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 421L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 422L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 423L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 424L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 425L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 426L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 427L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 428L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 429L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 430L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 431L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 432L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 433L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 434L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 435L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 436L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 437L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 438L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 439L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 440L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 441L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 442L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 443L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 444L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 445L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 446L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 447L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 448L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 449L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 450L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 15L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 451L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 452L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 453L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 454L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 455L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 456L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 457L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 458L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 459L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 460L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 461L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 462L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 463L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 464L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 465L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 466L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 467L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 468L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 469L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 470L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 471L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 472L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 473L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 474L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 475L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 476L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 477L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 478L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 479L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 480L, 8L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 16L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 481L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 482L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 483L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 484L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 485L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 486L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 487L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 488L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 489L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 490L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 491L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 492L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 493L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 494L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 495L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 496L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 497L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 498L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 499L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 500L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 501L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 502L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 503L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 504L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 505L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 506L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 507L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 508L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 509L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 510L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 17L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 511L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 512L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 513L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 514L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 515L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 516L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 517L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 518L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 519L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 520L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 521L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 522L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 523L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 524L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 525L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 526L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 527L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 528L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 529L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 530L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 531L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 532L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 533L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 534L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 535L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 536L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 537L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 538L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 539L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 540L, 9L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 18L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 541L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 542L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 543L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 544L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 545L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 546L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 547L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 548L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 549L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 550L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 551L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 552L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 553L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 554L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 555L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 556L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 557L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 558L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 559L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 560L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 561L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 562L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 563L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 564L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 565L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 566L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 567L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 568L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 569L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 570L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 19L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 571L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 572L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 573L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 574L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 575L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 576L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 577L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 578L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 579L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 580L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 581L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 582L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 583L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 584L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 585L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 586L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 587L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 588L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 589L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 590L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 591L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 21, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 592L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 593L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 594L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 595L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2025, 1, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 596L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2025, 1, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 597L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(2025, 1, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 598L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, null, new DateTime(2025, 1, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 599L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2025, 1, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 600L, 10L, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 20L, new DateTime(2025, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivationRequests_CourseId",
                table: "ActivationRequests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationRequests_TutorId",
                table: "ActivationRequests",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_BioTutor_TutorId",
                table: "BioTutor",
                column: "TutorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CourseId",
                table: "Certificates",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TutorId",
                table: "Certificates",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CourseId",
                table: "Contents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCancellations_CourseId",
                table: "CourseCancellations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCancellations_StudentId",
                table: "CourseCancellations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedByTutorId",
                table: "Courses",
                column: "CreatedByTutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CourseCancellationId",
                table: "Payments",
                column: "CourseCancellationId",
                unique: true,
                filter: "[CourseCancellationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CourseId",
                table: "Payments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TutorId",
                table: "Ratings",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_CourseId",
                table: "Slots",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_StudentId",
                table: "Slots",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_TutorId",
                table: "Slots",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_CourseId",
                table: "WeeklySchedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_SlotId",
                table: "WeeklySchedules",
                column: "SlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationRequests");

            migrationBuilder.DropTable(
                name: "BioTutor");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "WeeklySchedules");

            migrationBuilder.DropTable(
                name: "CourseCancellations");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
