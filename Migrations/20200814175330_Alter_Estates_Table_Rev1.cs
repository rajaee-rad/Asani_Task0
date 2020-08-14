using Microsoft.EntityFrameworkCore.Migrations;

namespace Asani_Task0.Migrations
{
    public partial class Alter_Estates_Table_Rev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Log",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdModifer",
                table: "Estates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Log",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "UserIdModifer",
                table: "Estates");
        }
    }
}
