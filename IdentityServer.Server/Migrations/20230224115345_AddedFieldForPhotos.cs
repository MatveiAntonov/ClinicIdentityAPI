using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Server.Migrations
{
    public partial class AddedFieldForPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d506b42-9fa0-4ef7-a92a-0b5b0a123665",
                column: "ConcurrencyStamp",
                value: "0711bbb7-d863-4824-820d-25ecbba79217");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1",
                column: "ConcurrencyStamp",
                value: "f1c9e555-70af-4315-809a-445bae8fae07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecce8cb1-99d3-45f2-8602-febbcfdc6f3c",
                column: "ConcurrencyStamp",
                value: "9577d02b-5146-48b0-86a5-2dba9664ab09");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Photos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d506b42-9fa0-4ef7-a92a-0b5b0a123665",
                column: "ConcurrencyStamp",
                value: "fd9aa0cc-ca27-48f2-be43-fcb4c466b732");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1",
                column: "ConcurrencyStamp",
                value: "24d8637b-105f-43bc-b402-d0cdb3a6e1e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecce8cb1-99d3-45f2-8602-febbcfdc6f3c",
                column: "ConcurrencyStamp",
                value: "fa450f56-e288-4f04-821c-bede8b2c0194");
        }
    }
}
