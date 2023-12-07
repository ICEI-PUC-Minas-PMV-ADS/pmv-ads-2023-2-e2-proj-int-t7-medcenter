using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medcenter_backend.Migrations
{
    public partial class M22AdicionandoExame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    DependenteId = table.Column<int>(type: "int", nullable: true),
                    ClinicaId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    DataExame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TipoExame = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exames_Dependentes_DependenteId",
                        column: x => x.DependenteId,
                        principalTable: "Dependentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exames_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exames_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exames_ClinicaId",
                table: "Exames",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_DependenteId",
                table: "Exames",
                column: "DependenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_MedicoId",
                table: "Exames",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteId",
                table: "Exames",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exames");
        }
    }
}
