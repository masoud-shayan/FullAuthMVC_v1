using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMvcAuth4.Data.Migrations
{
    public partial class deleteIdCardUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "43974793-ec73-40fc-a4e7-6e1b5fecfee5", "3d36eb89-892e-4799-940f-5557a3eaf496", "visitor", "VISITOR" },
                    { "1a53139f-c3de-4b3b-b01f-493b414c81c9", "4b0ca1f8-ba32-4a8d-93a3-8e15b2ff5167", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a53139f-c3de-4b3b-b01f-493b414c81c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43974793-ec73-40fc-a4e7-6e1b5fecfee5");

            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "AspNetUsers",
                type: "text",
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
    }
}
