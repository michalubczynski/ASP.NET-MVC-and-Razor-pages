using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wojewodztwa",
                columns: table => new
                {
                    WojewodzwoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wojewodztwa", x => x.WojewodzwoId);
                });

            migrationBuilder.CreateTable(
                name: "Miasta",
                columns: table => new
                {
                    MiastoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IleMieszkancow = table.Column<int>(type: "int", nullable: false),
                    WojewodztwoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miasta", x => x.MiastoId);
                    table.ForeignKey(
                        name: "FK_Miasta_Wojewodztwa_WojewodztwoId",
                        column: x => x.WojewodztwoId,
                        principalTable: "Wojewodztwa",
                        principalColumn: "WojewodzwoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miasta_WojewodztwoId",
                table: "Miasta",
                column: "WojewodztwoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Miasta");

            migrationBuilder.DropTable(
                name: "Wojewodztwa");
        }
    }
}
