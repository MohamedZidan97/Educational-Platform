using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopTeacher.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addOneNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "notifications",
               columns: new[] { "Id", "Title", "Description", "CreatedDate", "AcademicYear" },
               values: new object[] { Guid.NewGuid().ToString(), "Welcome Notifications", "First Notification", DateTime.UtcNow, "NotFound" }
               );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM [notifications]");
        }
    }
}
