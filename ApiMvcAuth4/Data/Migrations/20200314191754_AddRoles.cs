using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMvcAuth4.Data.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8fcaa526-04a8-4238-93cb-a32dd8041258", "208425bc-fbbf-480b-901b-78b3eb580aa9", "visitor", "VISITOR" },
                    { "0d474a42-1541-467c-ba6c-4897c2831080", "b4e4c2e0-2423-4aa7-bd97-85da4bc3ab0f", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d474a42-1541-467c-ba6c-4897c2831080");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fcaa526-04a8-4238-93cb-a32dd8041258");
        }
    }
}
