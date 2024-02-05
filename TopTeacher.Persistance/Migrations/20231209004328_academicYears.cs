using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopTeacher.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class academicYears : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "academicYears",
                columns: new[] { "AcademicYearId", "Name" },
                values: new object[] { Guid.NewGuid().ToString(), "First" }
                );
            migrationBuilder.InsertData(
               table: "academicYears",
               columns: new[] { "AcademicYearId", "Name" },
               values: new object[] { Guid.NewGuid().ToString(), "Second" }
               );
            migrationBuilder.InsertData(
                table: "academicYears",
                columns: new[] { "AcademicYearId", "Name" },
                values: new object[] { Guid.NewGuid().ToString(), "Third" }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM [academicYears]");
        }

    }
}
