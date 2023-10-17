using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medcenter_backend.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(16)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Usuarios");
        }
    }
}
