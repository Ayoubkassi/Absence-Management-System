using Microsoft.EntityFrameworkCore.Migrations;

namespace Absence.Migrations
{
    public partial class addStudentUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdStudent",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdStudent",
                table: "User",
                column: "IdStudent",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Students_IdStudent",
                table: "User",
                column: "IdStudent",
                principalTable: "Students",
                principalColumn: "IdStudent",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Students_IdStudent",
                table: "User");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_User_IdStudent",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdStudent",
                table: "User");
        }
    }
}
