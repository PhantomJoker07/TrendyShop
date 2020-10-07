using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class try4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Security");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Security",
                table: "AspNetUsers",
                newName: "AspNetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Security",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AspNetUserId",
                table: "AspNetUsers",
                newName: "Id");
        }
    }
}
