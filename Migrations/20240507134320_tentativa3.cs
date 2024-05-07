using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroConnect.Migrations
{
    /// <inheritdoc />
    public partial class tentativa3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gadoHistoricos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Saude = table.Column<string>(type: "text", nullable: false),
                    Reproducao = table.Column<string>(type: "text", nullable: false),
                    Vacina = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gadoHistoricos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plantacoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    DataPlantio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataColheita = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gados",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Raca = table.Column<string>(type: "text", nullable: false),
                    Peso = table.Column<double>(type: "double precision", nullable: false),
                    HistoricoId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gados_gadoHistoricos_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "gadoHistoricos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gados_HistoricoId",
                table: "gados",
                column: "HistoricoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gados");

            migrationBuilder.DropTable(
                name: "plantacoes");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "gadoHistoricos");
        }
    }
}
