using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplexContactApp.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Setgoal",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "GoalSelect",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalSelect",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "Setgoal",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
