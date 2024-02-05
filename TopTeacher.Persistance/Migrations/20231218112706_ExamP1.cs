using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopTeacher.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ExamP1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chooseQuestions",
                columns: table => new
                {
                    ChooseQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    A = table.Column<bool>(type: "bit", nullable: false),
                    B = table.Column<bool>(type: "bit", nullable: false),
                    C = table.Column<bool>(type: "bit", nullable: false),
                    D = table.Column<bool>(type: "bit", nullable: false),
                    AcademicYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chooseQuestions", x => x.ChooseQuestionId);
                    table.ForeignKey(
                        name: "FK_chooseQuestions_academicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "academicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_exams_academicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "academicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trueAndFalseQuestions",
                columns: table => new
                {
                    TrueAndFalseQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    IsFalse = table.Column<bool>(type: "bit", nullable: false),
                    AcademicYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trueAndFalseQuestions", x => x.TrueAndFalseQuestionId);
                    table.ForeignKey(
                        name: "FK_trueAndFalseQuestions_academicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "academicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamAndChooseQuestion",
                columns: table => new
                {
                    ChooseQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAndChooseQuestion", x => new { x.ExamId, x.ChooseQuestionId });
                    table.ForeignKey(
                        name: "FK_ExamAndChooseQuestion_chooseQuestions_ChooseQuestionId",
                        column: x => x.ChooseQuestionId,
                        principalTable: "chooseQuestions",
                        principalColumn: "ChooseQuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamAndChooseQuestion_exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamAndTFQuestion",
                columns: table => new
                {
                    TrueAndFalseQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAndTFQuestion", x => new { x.ExamId, x.TrueAndFalseQuestionId });
                    table.ForeignKey(
                        name: "FK_ExamAndTFQuestion_exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamAndTFQuestion_trueAndFalseQuestions_TrueAndFalseQuestionId",
                        column: x => x.TrueAndFalseQuestionId,
                        principalTable: "trueAndFalseQuestions",
                        principalColumn: "TrueAndFalseQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chooseQuestions_AcademicYearId",
                table: "chooseQuestions",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAndChooseQuestion_ChooseQuestionId",
                table: "ExamAndChooseQuestion",
                column: "ChooseQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAndTFQuestion_TrueAndFalseQuestionId",
                table: "ExamAndTFQuestion",
                column: "TrueAndFalseQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_exams_AcademicYearId",
                table: "exams",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_trueAndFalseQuestions_AcademicYearId",
                table: "trueAndFalseQuestions",
                column: "AcademicYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamAndChooseQuestion");

            migrationBuilder.DropTable(
                name: "ExamAndTFQuestion");

            migrationBuilder.DropTable(
                name: "chooseQuestions");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "trueAndFalseQuestions");
        }
    }
}
