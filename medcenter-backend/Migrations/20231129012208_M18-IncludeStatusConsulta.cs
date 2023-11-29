using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medcenter_backend.Migrations
{
    /// <inheritdoc />
    public partial class M18IncludeStatusConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Consultas");
        }
    }
}
