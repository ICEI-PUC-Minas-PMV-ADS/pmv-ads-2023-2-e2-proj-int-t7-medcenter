using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medcenter_backend.Migrations
{
    /// <inheritdoc />
    public partial class M12AddTableExames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "Profissional",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "TipoExame",
                table: "Exames");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Exames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Exames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Exames");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Exames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Exames",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Profissional",
                table: "Exames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoExame",
                table: "Exames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
