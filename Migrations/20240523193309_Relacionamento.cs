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
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "plantacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "plantacoes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Dono",
                table: "gados",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "gados",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "gados",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "Vacina",
                table: "gadoHistoricos",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_plantacoes_UsuarioId1",
                table: "plantacoes",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_gados_UsuarioId1",
                table: "gados",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_gados_usuarios_UsuarioId1",
                table: "gados",
                column: "UsuarioId1",
                principalTable: "usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plantacoes_usuarios_UsuarioId1",
                table: "plantacoes",
                column: "UsuarioId1",
                principalTable: "usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gados_usuarios_UsuarioId1",
                table: "gados");

            migrationBuilder.DropForeignKey(
                name: "FK_plantacoes_usuarios_UsuarioId1",
                table: "plantacoes");

            migrationBuilder.DropIndex(
                name: "IX_plantacoes_UsuarioId1",
                table: "plantacoes");

            migrationBuilder.DropIndex(
                name: "IX_gados_UsuarioId1",
                table: "gados");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "plantacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "plantacoes");

            migrationBuilder.DropColumn(
                name: "Dono",
                table: "gados");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "gados");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "gados");

            migrationBuilder.AlterColumn<string>(
                name: "Vacina",
                table: "gadoHistoricos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]");
        }
    }
}
