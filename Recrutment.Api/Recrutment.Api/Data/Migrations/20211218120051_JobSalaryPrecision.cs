using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recrutment.Api.Migrations
{
    public partial class JobSalaryPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(38,18)",
                precision: 38,
                scale: 18,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldPrecision: 38,
                oldScale: 18);
        }
    }
}
