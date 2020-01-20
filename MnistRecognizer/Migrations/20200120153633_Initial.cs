using Microsoft.EntityFrameworkCore.Migrations;

namespace MnistRecognizer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numerPrzedstawiany = table.Column<int>(nullable: false),
                    nazwaObrazka = table.Column<string>(nullable: true),
                    resultsString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Layers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkID = table.Column<int>(nullable: false),
                    KernelLength = table.Column<int>(nullable: false),
                    KernelWidth = table.Column<int>(nullable: false),
                    Stride = table.Column<int>(nullable: false),
                    Padding = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Layers_Networks_NetworkID",
                        column: x => x.NetworkID,
                        principalTable: "Networks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Layers_NetworkID",
                table: "Layers",
                column: "NetworkID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Layers");

            migrationBuilder.DropTable(
                name: "Networks");
        }
    }
}
