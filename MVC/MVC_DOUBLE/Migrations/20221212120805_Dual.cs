using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCDOUBLE.Migrations
{
    /// <inheritdoc />
    public partial class Dual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupy",
                columns: table => new
                {
                    GrupaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupy", x => x.GrupaId);
                });

            migrationBuilder.CreateTable(
                name: "Studenci",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenci", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Studenci_Grupy_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupy",
                        principalColumn: "GrupaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenci_GrupaId",
                table: "Studenci",
                column: "GrupaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenci");

            migrationBuilder.DropTable(
                name: "Grupy");
        }
    }
}
