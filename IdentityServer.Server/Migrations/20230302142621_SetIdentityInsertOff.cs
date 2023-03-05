using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Server.Migrations
{
    public partial class SetIdentityInsertOff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d506b42-9fa0-4ef7-a92a-0b5b0a123665",
                column: "ConcurrencyStamp",
                value: "2879572f-0676-4ff8-8afa-fc1b1dc7de7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1",
                column: "ConcurrencyStamp",
                value: "fa855961-6465-4c97-a801-17618a26ada8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecce8cb1-99d3-45f2-8602-febbcfdc6f3c",
                column: "ConcurrencyStamp",
                value: "0c48df6b-8317-499b-9e2f-794bec9229fb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
