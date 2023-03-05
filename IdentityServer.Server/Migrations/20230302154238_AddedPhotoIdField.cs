using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Server.Migrations
{
    public partial class AddedPhotoIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d506b42-9fa0-4ef7-a92a-0b5b0a123665",
                column: "ConcurrencyStamp",
                value: "94e11b29-8fc6-42b5-8be4-d26c22124206");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1",
                column: "ConcurrencyStamp",
                value: "2358cfd8-2e64-4a1b-b128-61108b57f271");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecce8cb1-99d3-45f2-8602-febbcfdc6f3c",
                column: "ConcurrencyStamp",
                value: "4b9af709-31d8-47c8-9981-223c0dc14c55");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoId",
                table: "Photos",
                column: "PhotoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photos_PhotoId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Photos");

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
    }
}
