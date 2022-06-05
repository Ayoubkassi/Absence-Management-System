using Microsoft.EntityFrameworkCore.Migrations;

namespace Absence.Migrations
{
    public partial class AbsenceAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentJustification",
                table: "Absences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsJustified",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LetterJustification",
                table: "Absences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentJustification",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "IsJustified",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "LetterJustification",
                table: "Absences");
        }
    }
}
