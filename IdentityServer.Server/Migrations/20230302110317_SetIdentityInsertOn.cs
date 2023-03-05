using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Server.Migrations
{
    public partial class SetIdentityInsertOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d506b42-9fa0-4ef7-a92a-0b5b0a123665",
                column: "ConcurrencyStamp",
                value: "1c1a3f60-53a2-4003-9fd1-0035a240e658");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1",
                column: "ConcurrencyStamp",
                value: "ac1db833-b9b1-4b5d-8996-87f8a75418a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecce8cb1-99d3-45f2-8602-febbcfdc6f3c",
                column: "ConcurrencyStamp",
                value: "73688e56-cd28-40b2-a7cb-b74907919eeb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
