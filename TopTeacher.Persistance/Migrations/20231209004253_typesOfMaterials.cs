using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopTeacher.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class typesOfMaterials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "typesOfMaterials",
                columns: new[] { "TypeOfMaterialId", "Name" },
                values: new object[] { Guid.NewGuid().ToString(), "Explanation video" }
                );
            migrationBuilder.InsertData(
               table: "typesOfMaterials",
               columns: new[] { "TypeOfMaterialId", "Name" },
               values: new object[] { Guid.NewGuid().ToString(), "Solution video" }
               );
            migrationBuilder.InsertData(
                table: "typesOfMaterials",
                columns: new[] { "TypeOfMaterialId", "Name" },
                values: new object[] { Guid.NewGuid().ToString(), "Documents" }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM [typesOfMaterials]");
        }


    }
}
