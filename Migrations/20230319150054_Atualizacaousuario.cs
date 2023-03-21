using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacaousuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "tb_Usuario");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_Usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_Usuario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "tb_Usuario",
                newName: "dtNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Usuario",
                table: "tb_Usuario",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Usuario",
                table: "tb_Usuario");

            migrationBuilder.RenameTable(
                name: "tb_Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "dtNascimento",
                table: "Usuarios",
                newName: "DataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }
    }
}
