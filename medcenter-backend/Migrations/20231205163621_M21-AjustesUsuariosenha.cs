using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medcenter_backend.Migrations
{
    /// <inheritdoc />
    public partial class M21AjustesUsuariosenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenRedefinicaoSenha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenRedefinicaoSenha",
                table: "Usuarios");
        }
    }
}
