using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Czolgi.Migrations
{
    /// <inheritdoc />
    public partial class firste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Czolgi",
                columns: table => new
                {
                    CzolgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kaliber = table.Column<double>(type: "float", nullable: false),
                    Masa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czolgi", x => x.CzolgId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Czolgi");
        }
    }
}
