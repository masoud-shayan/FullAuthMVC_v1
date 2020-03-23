using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMvcAuth4.Data.Migrations
{
    public partial class addIdCardUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d474a42-1541-467c-ba6c-4897c2831080");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fcaa526-04a8-4238-93cb-a32dd8041258");

            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23295b0e-a0cc-4702-be5f-6b35ffb378b6", "15a44891-4e11-461c-98bf-984898806c4a", "visitor", "VISITOR" },
                    { "f056de8d-3ce0-4df9-ab0e-251126690796", "d704ab84-6b2e-4e05-8632-22744eace12c", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23295b0e-a0cc-4702-be5f-6b35ffb378b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f056de8d-3ce0-4df9-ab0e-251126690796");

            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8fcaa526-04a8-4238-93cb-a32dd8041258", "208425bc-fbbf-480b-901b-78b3eb580aa9", "visitor", "VISITOR" },
                    { "0d474a42-1541-467c-ba6c-4897c2831080", "b4e4c2e0-2423-4aa7-bd97-85da4bc3ab0f", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
