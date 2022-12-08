using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class first2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partie",
                columns: table => new
                {
                    PartiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partie", x => x.PartiaId);
                });

            migrationBuilder.CreateTable(
                name: "Poslowie",
                columns: table => new
                {
                    PoselId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    PartiaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poslowie", x => x.PoselId);
                    table.ForeignKey(
                        name: "FK_Poslowie_Partie_PartiaId",
                        column: x => x.PartiaId,
                        principalTable: "Partie",
                        principalColumn: "PartiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poslowie_PartiaId",
                table: "Poslowie",
                column: "PartiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poslowie");

            migrationBuilder.DropTable(
                name: "Partie");
        }
    }
}
