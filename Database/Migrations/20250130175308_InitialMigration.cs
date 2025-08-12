using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Productoras",
                columns: table => new
                {
                    IdProductora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productoras", x => x.IdProductora);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    IdSerie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnlaceYouTube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProductora = table.Column<int>(type: "int", nullable: false),
                    IdGenero1 = table.Column<int>(type: "int", nullable: false),
                    IdGenero2 = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.IdSerie);
                    table.ForeignKey(
                        name: "FK_Series_Generos_IdGenero1",
                        column: x => x.IdGenero1,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Generos_IdGenero2",
                        column: x => x.IdGenero2,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Productoras_IdProductora",
                        column: x => x.IdProductora,
                        principalTable: "Productoras",
                        principalColumn: "IdProductora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdGenero1",
                table: "Series",
                column: "IdGenero1");

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdGenero2",
                table: "Series",
                column: "IdGenero2");

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdProductora",
                table: "Series",
                column: "IdProductora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Productoras");
        }
    }
}
