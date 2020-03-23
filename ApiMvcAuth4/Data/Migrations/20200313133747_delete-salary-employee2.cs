using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMvcAuth4.Data.Migrations
{
    public partial class deletesalaryemployee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
