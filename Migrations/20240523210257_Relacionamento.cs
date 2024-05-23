using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroConnect.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "plantacoes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Dono",
                table: "gados",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "gados",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_plantacoes_UsuarioId",
                table: "plantacoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_gados_UsuarioId",
                table: "gados",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_gados_usuarios_UsuarioId",
                table: "gados",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plantacoes_usuarios_UsuarioId",
                table: "plantacoes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gados_usuarios_UsuarioId",
                table: "gados");

            migrationBuilder.DropForeignKey(
                name: "FK_plantacoes_usuarios_UsuarioId",
                table: "plantacoes");

            migrationBuilder.DropIndex(
                name: "IX_plantacoes_UsuarioId",
                table: "plantacoes");

            migrationBuilder.DropIndex(
                name: "IX_gados_UsuarioId",
                table: "gados");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "plantacoes");

            migrationBuilder.DropColumn(
                name: "Dono",
                table: "gados");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "gados");
        }
    }
}
