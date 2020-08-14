using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asani_Task0.Migrations
{
    public partial class Alter_Estates_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Estates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserIdCreator",
                table: "Estates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "UserIdCreator",
                table: "Estates");
        }
    }
}
