using Microsoft.EntityFrameworkCore.Migrations;

namespace medcenter_backend.Migrations
{
    public partial class Revert_feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
