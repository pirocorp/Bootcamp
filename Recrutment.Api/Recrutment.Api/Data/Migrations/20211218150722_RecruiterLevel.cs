using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recrutment.Api.Migrations
{
    public partial class RecruiterLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Recruiters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Recruiters");
        }
    }
}
