using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjectWorkServiceCatalogo.DL.Migrations
{
    public partial class addprodotto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODOTTO",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FK_CATEGORIA = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    PREZZO = table.Column<decimal>(type: "numeric", nullable: false),
                    PESO = table.Column<decimal>(type: "numeric", nullable: true),
                    DISPONIBILITA = table.Column<int>(type: "integer", nullable: false),
                    DESCRIZIONE = table.Column<string>(type: "text", nullable: true),
                    IMMAGINE = table.Column<string>(type: "text", nullable: true),
                    MATERIALE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODOTTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODOTTO_CATEGORIA_FK_CATEGORIA",
                        column: x => x.FK_CATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODOTTO_FK_CATEGORIA",
                table: "PRODOTTO",
                column: "FK_CATEGORIA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODOTTO");
        }
    }
}
