using Microsoft.EntityFrameworkCore.Migrations;

namespace Absence.Migrations
{
    public partial class AbsenceAttribute2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notice",
                table: "Absences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notice",
                table: "Absences");
        }
    }
}
