using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medcenter_backend.Migrations
{
    /// <inheritdoc />
    public partial class M11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Exames");

            migrationBuilder.RenameColumn(
                name: "Profissional",
                table: "Exames",
                newName: "Paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Paciente",
                table: "Exames",
                newName: "Profissional");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Exames",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Exames",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
