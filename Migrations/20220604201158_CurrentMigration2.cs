using Microsoft.EntityFrameworkCore.Migrations;

namespace Absence.Migrations
{
    public partial class CurrentMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prof",
                table: "Prof");

            migrationBuilder.RenameTable(
                name: "Prof",
                newName: "Profs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profs",
                table: "Profs",
                column: "IdProf");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdAdmin);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profs",
                table: "Profs");

            migrationBuilder.RenameTable(
                name: "Profs",
                newName: "Prof");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prof",
                table: "Prof",
                column: "IdProf");
        }
    }
}
