using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroConnect.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamento1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UsuarioId1",
                table: "plantacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "gados");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "plantacoes",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "gados",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "plantacoes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "plantacoes",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "gados",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "gados",
                type: "text",
                nullable: true);

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
    }
}
