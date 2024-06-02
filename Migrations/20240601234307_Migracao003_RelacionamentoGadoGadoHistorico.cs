using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroConnect.Migrations
{
    /// <inheritdoc />
    public partial class Migracao003_RelacionamentoGadoGadoHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_gados_HistoricoId",
                table: "gados");

            migrationBuilder.AddColumn<int>(
                name: "GadoId",
                table: "gadoHistoricos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_gados_HistoricoId",
                table: "gados",
                column: "HistoricoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_gadoHistoricos_GadoId",
                table: "gadoHistoricos",
                column: "GadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_gadoHistoricos_gados_GadoId",
                table: "gadoHistoricos",
                column: "GadoId",
                principalTable: "gados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gadoHistoricos_gados_GadoId",
                table: "gadoHistoricos");

            migrationBuilder.DropIndex(
                name: "IX_gados_HistoricoId",
                table: "gados");

            migrationBuilder.DropIndex(
                name: "IX_gadoHistoricos_GadoId",
                table: "gadoHistoricos");

            migrationBuilder.DropColumn(
                name: "GadoId",
                table: "gadoHistoricos");

            migrationBuilder.CreateIndex(
                name: "IX_gados_HistoricoId",
                table: "gados",
                column: "HistoricoId");
        }
    }
}
