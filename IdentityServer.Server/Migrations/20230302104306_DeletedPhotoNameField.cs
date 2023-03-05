using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Server.Migrations
{
    public partial class DeletedPhotoNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d506b42-9fa0-4ef7-a92a-0b5b0a123665",
                column: "ConcurrencyStamp",
                value: "591255a2-1c36-4633-a2ac-cdf8b6804c28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1",
                column: "ConcurrencyStamp",
                value: "70a5f7f1-352c-4ac9-aec7-15f0cb7ed8fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecce8cb1-99d3-45f2-8602-febbcfdc6f3c",
                column: "ConcurrencyStamp",
                value: "bb928133-e1ac-4966-a823-1ef050601900");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
